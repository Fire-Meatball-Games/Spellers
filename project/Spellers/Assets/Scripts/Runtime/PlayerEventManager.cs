using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CustomEventSystem;

namespace Runtime
{
    public class PlayerEventManager : MonoBehaviour
    {
        private int total_spells;
        private int streak_spells;
        
        public int TotalSpells { get => total_spells; set => total_spells = value; }
        public int StreakSpells { get => streak_spells; set => streak_spells = value; }

        public PlayerEvent TotalSpellsEvent;

        public void Starts()
        {
            Events.OnPlayerUseSpell.AddListener(AddHit);
            Events.OnFailSpell.AddListener(AddFail);
        }

        private void AddHit()
        {
            TotalSpells++;
            StreakSpells++;
        }

        private void AddFail()
        {
            TotalSpells++;
            StreakSpells = 0;
        }
    }

}