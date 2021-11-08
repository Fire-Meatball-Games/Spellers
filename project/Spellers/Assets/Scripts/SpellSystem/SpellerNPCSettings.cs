using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpellSystem
{
    [CreateAssetMenu(fileName = "Enemy_Settings", menuName = "Spellers/SpellerNPCSettings", order = 3)]
    public class SpellerNPCSettings : ScriptableObject
    {
        #region Fields
        public string spellerName;
        public SpellDeck deck;
        public int max_health = 100;
        public int max_spell_lvl = 3;
        public float cooldown_average;
        public float cooldown_deviation;
        #endregion

        #region Constructor

        public SpellerNPCSettings(string spellerName, SpellDeck deck, int max_health,
            int max_spell_lvl, float cooldown_average, float cooldown_deviation)
        {
            this.spellerName = spellerName;
            this.deck = deck;
            this.max_health = max_health;
            this.max_spell_lvl = max_spell_lvl;
            this.cooldown_average = cooldown_average;
            this.cooldown_deviation = cooldown_deviation;
        }

        #endregion

    }

}