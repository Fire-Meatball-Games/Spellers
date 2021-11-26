using UnityEngine;
using System.Collections.Generic;
using System;
using System.Linq;

namespace SpellSystem
{
    [Serializable]
    public class SpellDeck
    {
        public static readonly int DECKSIZE = 12;
        public List<Spell> spells;

        public SpellDeck()
        {
            this.spells = new List<Spell>(DECKSIZE);
        }

        public SpellDeck(IEnumerable<Spell> spells)
        {
            this.spells = new List<Spell>(spells);
        }

        public void AddSpell(Spell spell)
        {
            spells.Add(spell);
        }

        public SpellUnit GetRandomSpell()
        {
            System.Random rnd = new System.Random();
            Spell spell = spells.OrderBy(x => rnd.Next()).First();
            return new SpellUnit(spell);          
        }

        public SpellUnit GetRandomSpellWithlvlMax(int n)
        {
            System.Random rnd = new System.Random();
            Spell spell = spells.OrderBy(x => rnd.Next()).First();
            int lvl = UnityEngine.Random.Range(1, n + 1);
            return new SpellUnit(spell, lvl);
        }


        public List<SpellUnit> GetSpellPool(int size)
        {
            List<SpellUnit> spellUnits = new List<SpellUnit>(size);
            System.Random rnd = new System.Random();
            var spellpool = spells.OrderBy(x => rnd.Next()).Take(size);
            foreach (var spell in spellpool)
            {
                spellUnits.Add(new SpellUnit(spell));
            }
            return spellUnits;
        }

        public float GetAveragePower()
        {
            float total_power = 0f;
            foreach (var spell in spells)
            {
                total_power += spell.power;
            }
            return total_power / spells.Count;
        }
    }
}