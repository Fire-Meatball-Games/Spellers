using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SpellSystem;

namespace Ingame
{
    [System.Serializable]
    public class EnemyController
    {
        public SpellDeck deck;
        public int max_spell_lvl;
        public float cooldown_average;
        public float cooldown_deviation;
    }

}
