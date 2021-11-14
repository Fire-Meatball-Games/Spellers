using System;
using System.Collections.Generic;
using UnityEngine;

namespace Runtime
{
    [CreateAssetMenu(fileName = "PlayerEvent", menuName = "Spellers/PlayerEvent", order = 0)]
    public class PlayerEvent : ScriptableObject
    {
        private event Action<int> action = delegate { };

        public void Invoke(int value)
        {
            action?.Invoke(value);
        }

        public void SetListener(Action<int> listener)
        {
            action = listener;
        }

        public void Clear()
        {
            action = null;
        }

    }
}