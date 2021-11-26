using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpellSystem
{
    public struct SpellUnit
    {
        public Spell spell;
        public int lvl;

        public SpellUnit(Spell spell, int lvl)
        {
            this.spell = spell;
            this.lvl = spell.power < 3 ? lvl : 3;
        }

        public SpellUnit(Spell spell)
        {            
            this.spell = spell;
            this.lvl = spell.power < 3 ? Random.Range(1,4) : 3;
        }

        public override string ToString()
        {
            return spell.spellName + " " + lvl;
        }
    }   
}