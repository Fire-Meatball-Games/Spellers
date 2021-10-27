using UnityEngine;
using System.Collections.Generic;
using System;

namespace SpellSystem
{
    public class SpellDeck
    {
        public List<Spell> spells;

        public SpellDeck()
        {
            this.spells = new List<Spell>();
        }

        public SpellDeck(IEnumerable<Spell> spells)
        {
            this.spells = new List<Spell>(spells);
        }

        public void AddSpell(Spell spell)
        {
            spells.Add(spell);
        }

    }
}