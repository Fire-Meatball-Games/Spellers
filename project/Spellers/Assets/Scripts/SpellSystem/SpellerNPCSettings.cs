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
        public Sprite icon;
        public SpellDeck deck;
        public int max_spell_lvl = 3;
        public float cooldown_average;
        public float cooldown_deviation;

        #endregion


    }

}