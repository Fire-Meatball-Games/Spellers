using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CustomEventSystem;

namespace Runtime
{
    public class PlayerEventManager : MonoBehaviour
    {
        private int total_hits;
        private int total_tries;
        private int total_fails;


        public PlayerEvent totalSpellsEvent;

        public int TotalHits { 
            get => total_hits; 
            set { 
                totalSpellsEvent?.Invoke(value); 
                total_hits = value; 
            }  
        
        }
        public int TotalTries{ get => total_tries; set => total_tries = value; }
        public int TotalFails { get => total_fails; set => total_fails = value; }


        private void OnEnable()
        {
            Events.OnPlayerUseSpell.AddListener(AddHit);
            Events.OnFailSpell.AddListener(AddFail);
        }

        private void OnDisable()
        {
            Events.OnPlayerUseSpell.RemoveListener(AddHit);
            Events.OnFailSpell.RemoveListener(AddFail);
        }

        private void AddHit()
        {
            TotalHits++;
            TotalTries++;
        }

        private void AddFail()
        {
            TotalFails++;
            TotalTries++;
        }

    }

}