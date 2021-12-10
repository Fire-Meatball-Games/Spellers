using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tweening
{
    public class EffectBuilder
    {
        private readonly List<IUIEffect> _effects = new List<IUIEffect>();
        private readonly MonoBehaviour behaviour;

        private event Action action = delegate { };

        public EffectBuilder(MonoBehaviour behaviour)
        {
            this.behaviour = behaviour;
        }

        public EffectBuilder AddEffect(IUIEffect effect)
        {
            _effects.Add(effect);
            return this;
        }

        public void ExecuteEffects()
        {
            behaviour.StopAllCoroutines();
            foreach (var effect in _effects)
            {
                behaviour.StartCoroutine(effect.Execute());
            }
        }
    } 
}
