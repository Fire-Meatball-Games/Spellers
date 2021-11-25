using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tweening
{
    public abstract class CallbackEffect
    {
        private event Action action = delegate { };
        private EffectBuilder listener;

        public abstract void SetListener();
    }

}