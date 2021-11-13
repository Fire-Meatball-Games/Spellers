using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CustomEventSystem;

namespace Runtime
{
    public class PlayerEventManager : MonoBehaviour
    {
        private int total_spells;

        public List<PlayerEvent> TotalSpellsEvents;

        public int TotalSpells { 
            get => total_spells;
            set
            {
                foreach (PlayerEvent playerEvent in TotalSpellsEvents)
                {
                    if (playerEvent.value == value)
                        playerEvent.Invoke();
                }
                total_spells = value;
            } 
        }        

        private void Awake()
        {
            Events.OnPlayerUseSpell.AddListener(AddHit);
            Events.OnFailSpell.AddListener(AddFail);
        }

        private void AddHit()
        {
            TotalSpells++;
        }

        private void AddFail()
        {
            TotalSpells++;
        }
    }

}