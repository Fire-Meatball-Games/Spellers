using System;
using System.Collections.Generic;
using UnityEngine;

namespace Levels
{
    [CreateAssetMenu(fileName = "PlayerEvent", menuName = "Spellers/PlayerEvent", order = 0)]
    public class PlayerEvent : ScriptableObject
    {
        private event Action<int> action = delegate { };

        public void Invoke(int value)
        {
            action?.Invoke(value);
        }

        public void AddListener(Action<int> listener)
        {
            action += listener;
        }

        public void Clear()
        {
            action = null;
        }

    }
}