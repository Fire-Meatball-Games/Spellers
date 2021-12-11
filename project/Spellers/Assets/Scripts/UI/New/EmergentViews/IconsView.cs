using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Tweening;

namespace UIManagement
{
    public class IconsView : EmergentView
    {
        [SerializeField] private Image selected_icon_image;
        [SerializeField] private Button save_btn;
        [SerializeField] private RectTransform panel;

        public override void Init()
        {
            close_time = 0.1f;
            base.Init();
            save_btn.onClick.AddListener(SaveIconChange);
            show_effects.AddEffect(new ScreenSlideEffect(panel, Vector3.up, Vector3.zero, 1.1f, 0.2f));
            hide_effects.AddEffect(new ScreenSlideEffect(panel, Vector3.zero, Vector2.up, 1f, 0.1f));

        }

        private void SaveIconChange()
        {
            base.Hide();
        }
    }

}