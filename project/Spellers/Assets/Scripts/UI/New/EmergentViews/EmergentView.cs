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

        protected float close_time;
        protected EffectBuilder show_effects;
        protected EffectBuilder hide_effects;

        private void Awake() => Init();

        public override void Init()
        {
            Debug.Log(close_time);
            show_effects = new EffectBuilder(this);
            hide_effects = new EffectBuilder(this)
                .AddEffect(new EnableEffect(gameObject, close_time, false));
            btn_close.onClick.AddListener(Hide);
        }

        public override void Hide()
        {
            hide_effects.ExecuteEffects();
        }

        public override void Show()
        {
            base.Show();
            show_effects.ExecuteEffects();
        }


    }

}