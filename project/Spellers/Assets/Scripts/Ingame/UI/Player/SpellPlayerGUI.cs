using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tweening;

namespace Ingame.UI
{
    public abstract class SpellPlayerGUI : MonoBehaviour
    {
        [SerializeField] private RectTransform layout;
        protected SpellerPlayer player;

        private EffectBuilder showEffects, hideEffects;
        private void Awake() => Init();
        protected virtual void Init() 
        {
            showEffects = new EffectBuilder(this)
            .AddEffect(new EnableEffect(layout.gameObject, 0, true));
            hideEffects = new EffectBuilder(this)
            .AddEffect(new EnableEffect(layout.gameObject, 0.2f, false));
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
