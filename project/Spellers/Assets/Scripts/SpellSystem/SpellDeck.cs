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

        #region Private fields
        public List<Spell> spells;
        #endregion

        #region Properties
        public Spell this[int idx] => GetSpellAt(idx);
        public int Count => spells.Count;

        #endregion

        #region Constructors
        public SpellDeck()
        {
            this.spells = new List<Spell>();
        }

        public SpellDeck(IEnumerable<Spell> spells)
        {
            this.spells = new List<Spell>(spells);
        }
        #endregion

        #region Public Methods

        // Añade un hechizo al mazo:
        public void AddSpell(Spell spell)
        {
            if(!Contains(spell) && !isFull())
                spells.Add(spell);
        }

        // Elimina un hechizo del mazo:
        public void RemoveSpell(Spell spell)
        {
            spells.Remove(spell);
        }

        // Devuelve un hechizo aleatorio del mazo
        public SpellUnit GetRandomSpell(int maxLvl = 3)
        {
            System.Random rnd = new System.Random();
            Spell spell = spells.OrderBy(x => rnd.Next()).First();
            int lvl = UnityEngine.Random.Range(1, maxLvl + 1);
            return new SpellUnit(spell, lvl);          
        }

        // Devuelve un conjunto de hechizos aleatorio del mazo
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

        public List<Spell> ToList()
        {
            return spells;
        }

        // Devuelve la potencia media de los hechizos del mazo
        public float GetAveragePower()
        {
            if(spells.Count == 0) return 0f;

            float total_power = 0f;
            foreach (var spell in spells)
            {
                total_power += spell.Power;
            }
            return total_power / spells.Count;            
        }      

        //Devuelve si un mazo es valido, si tiene al menos un hechizo de ataque.

        public bool IsValid()
        {
            return spells.FindAll((spell) => spell.type == Spell.Type.Ataque).Count > 0;
        }

        // Devuelve si el mazo contiene un hechizo determinado
        public bool Contains(Spell spell)
        {
            return spells.Contains(spell);
        }

        // Devuelve si un hechizo se puede añadir
        public bool CanAdd(Spell spell)
        {
            return !(Contains(spell) || isFull());
        }

        // Devuelve si un mazo está lleno
        public bool isFull()
        {
            return spells.Count >= DECKSIZE;
        }
        #endregion

        private Spell GetSpellAt(int idx)
        {
            if(idx >= 0 && idx < spells.Count)
            {
                return spells[idx];
            }
            else
            {
                Debug.LogWarning("Index out of the deck range");
                return null;
            }
        }
        
    }
}