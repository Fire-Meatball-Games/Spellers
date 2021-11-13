using System.Collections.Generic;
using UnityEngine;

namespace Runtime
{
    [CreateAssetMenu(fileName = "PlayerEvent", menuName = "Spellers/PlayerEvent", order = 0)]
    public class PlayerEvent : ScriptableObject
    {
        public int value;

        public void Invoke()
        {

        }

        public void AddListener()
        {

        }
        
    }
}