using UnityEngine;
using System.Collections.Generic;
using System;

namespace SpellSystem
{
    [Serializable]
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

        public Spell GetRandomSpell()
        {
            System.Random random = new System.Random();
            int index = random.Next(spells.Count);
            return spells[index];
        }

    }
}