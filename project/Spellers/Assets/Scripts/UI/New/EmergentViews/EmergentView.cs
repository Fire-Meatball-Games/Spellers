using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Tweening;

namespace UIManagement
{
    public abstract class EmergentView : View
    {
        [SerializeField] private Button btn_close;
        [SerializeField] private GameObject layout;

        protected float close_time;
        protected EffectBuilder show_effects;
        protected EffectBuilder hide_effects;

        private void Awake() => Init();

        public override void Init()
        {
            show_effects = new EffectBuilder(this);
            hide_effects = new EffectBuilder(this)
                .AddEffect(new EnableEffect(layout, close_time, false));
            btn_close.onClick.AddListener(Hide);
        }

        public override void Hide()
        {
            hide_effects.ExecuteEffects();
        }

        public override void Show()
        {
            Debug.Log("AA");
            layout.SetActive(true);
            show_effects.ExecuteEffects();
        }
    }

}