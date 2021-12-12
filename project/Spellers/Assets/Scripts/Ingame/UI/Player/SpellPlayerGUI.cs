using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tweening;

namespace Ingame.UI
{
    public abstract class SpellPlayerGUI : MonoBehaviour
    {
        [SerializeField] protected RectTransform layout;
        protected SpellerPlayer player;

        private EffectBuilder showEffects, hideEffects;
        private void Awake() => Init();
        protected virtual void Init() 
        {
            showEffects = new EffectBuilder(this)
            .AddEffect(new EnableEffect(layout.gameObject, 0, true))
            .AddEffect(new ScreenSlideEffect(layout, Vector2.right * 0.5f, Vector2.zero, 1.2f, 0.3f));

            hideEffects = new EffectBuilder(this)
            .AddEffect(new EnableEffect(layout.gameObject, 0.2f, false))
            .AddEffect(new ScreenSlideEffect(layout, Vector2.zero, Vector2.right * 0.5f, 1f, 0.2f));
        }
        
        public virtual void SetUp(SpellerPlayer player)
        {
            this.player = player;
        }

        public virtual void Hide() => hideEffects.ExecuteEffects();
        public virtual void Show() => showEffects.ExecuteEffects();

        public void ShowInstant() => layout.gameObject.SetActive(true);
        public void HideInstant() => layout.gameObject.SetActive(false);
    }

}
