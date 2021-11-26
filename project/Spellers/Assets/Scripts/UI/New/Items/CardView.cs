using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Tweening;

namespace UIManagement
{
    public class CardView : MonoBehaviour
    {
        [SerializeField] private Image icon_img;
        [SerializeField] private Button icon_button;
        [SerializeField] private Image lock_img;

        [SerializeField] private RectTransform contextMenu_rt;
        [SerializeField] private Button info_btn;
        [SerializeField] private Button use_btn;
        [SerializeField] private TextMeshProUGUI use_txt;

        private Sprite icon;
        private bool unlocked;
        private Action onClickAction = delegate{};

        private EffectBuilder showContextMenuEffects, hideContextMenuEffects;

        private void Awake() 
        {
            icon_button.onClick.AddListener(() => showContextMenuEffects.ExecuteEffects());
            use_btn.onClick.AddListener(() => hideContextMenuEffects.ExecuteEffects());
        }

        public void SetUp(Sprite icon, Action onClickAction, bool unlocked = true)
        {
            showContextMenuEffects = new EffectBuilder(this)
                .AddEffect(new ScaleRectEffect(contextMenu_rt, Vector3.zero, Vector3.one, 1.2f, 0.2f));
            hideContextMenuEffects = new EffectBuilder(this)
                .AddEffect(new ScaleRectEffect(contextMenu_rt, Vector3.one, Vector3.zero, 1f, 0.2f));
            this.icon = icon;
            this.unlocked = unlocked;
            this.onClickAction = onClickAction;
            SetLayout();
        }

        private void SetLayout()
        {
            icon_img.sprite = icon;
            lock_img.gameObject.SetActive(!unlocked);
            icon_button.interactable = unlocked;
            info_btn.onClick.AddListener(onClickAction.Invoke);
        }
    }
}

