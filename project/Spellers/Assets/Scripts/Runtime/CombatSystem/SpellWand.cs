using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SpellSystem;
using System;

namespace Runtime.CombatSystem
{
    public static class SpellWand 
    {
        public static void UseSpell(SpellUnit spellUnit, Speller user, Speller target)
        {
            int level = spellUnit.lvl;
            foreach(Effect effect in spellUnit.spell.effects)
            {
                effect.Apply(user.stats, target.stats, level);
            }
        }      
    } 
}
