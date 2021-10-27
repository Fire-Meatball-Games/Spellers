using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace SpellSystem
{
    [CreateAssetMenu(fileName = "SpellBook", menuName = "Spellers/SpellBook", order = 2)]
    public class SpellManager : ScriptableObject
    {
        public List<Spell> spells;

        public Spell GetSpell(int idx)
        {
            if (idx < spells.Count)
                return spells[idx];
            else
                throw new System.Exception();
        }

        public List<Spell> GetRandomSpells(int size)
        {
            System.Random rand = new System.Random();
            List<Spell> spell_list;
            spell_list = new List<Spell>(spells.OrderBy(x => rand.Next()).Take(size));
            return spell_list;
        }
    }
}