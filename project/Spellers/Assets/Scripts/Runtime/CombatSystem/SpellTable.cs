using UnityEngine;
using System.Collections.Generic;
using SpellSystem;
using CustomEventSystem;
using System.Linq;

namespace Runtime.CombatSystem
{
    [SerializeField]
    public class SpellTable
    {
        #region Fields 
        private const int BASE_SLOTS = 3;

        private SpellDeck deck;
        private List<SpellUnit> spellSlots;
        private SpellUnit selectedSpell;
        private int num_slots = BASE_SLOTS;
        #endregion

        #region Constructor

        public SpellTable(SpellDeck deck)
        {
            this.deck = deck;
        }

        #endregion

        #region public Methods        

        // Selecciona el hechizo 
        public SpellUnit SelectSpellSlot(int idx)
        {
            selectedSpell = spellSlots[idx];
            ChangeSpellSlot(idx);
            Events.OnSelectSpellSlot.Invoke(idx);
            return selectedSpell;
        }

        // Devuelve el hechizo seleccionado
        public SpellUnit GetSelectedSpell()
        {
            return selectedSpell;
        }

        // Carga los hechizos iniciales
        public void Initialize()
        {
            GenerateSpellSlots();
        }
        #endregion

        #region private Methods

        // Coloca 3 hechizos aleatorios del mazo del jugador a la mesa
        private void GenerateSpellSlots()
        {
            var rand = new System.Random();
            for (int i = 0; i < num_slots; i++)
            {
                Spell spell = deck.spells[new System.Random().Next(deck.spells.Count)];
                int lvl = spell.power < 3 ? new System.Random().Next(1, 3) : 3;
                spellSlots[i] = new SpellUnit(spell, lvl);
            }
            Events.OnGenerateSpellSlots.Invoke(spellSlots);
        }

        // Cambia el hechizo de la posición idx de la mesa
        private void ChangeSpellSlot(int idx)
        {
            Spell spell = deck.spells[new System.Random().Next(deck.spells.Count)];
            int lvl = spell.power < 3 ? new System.Random().Next(1, 3) : 3;
            spellSlots[idx] = new SpellUnit(spell, lvl);
            Events.OnChangeSpellSlot.Invoke(idx, spellSlots[idx]);
        }

        #endregion


    }
}