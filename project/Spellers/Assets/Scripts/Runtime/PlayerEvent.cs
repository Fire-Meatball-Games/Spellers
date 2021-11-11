using System.Collections.Generic;
using UnityEngine;

namespace Runtime
{
    [CreateAssetMenu(fileName = "PlayerEvent", menuName = "Spellers/PlayerEvent", order = 0)]
    public class PlayerEvent : ScriptableObject
    {
        public int value;
        //public List<PlayerEventHandler> handlers;

        public void Invoke()
        {
            //for (int i = handlers.Count -1; i >= 0; i--)
            //{
            //    handlers.Run();    
            //}
        }

        
    }
}