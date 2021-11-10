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
        private List<SpellUnit> spellSlots = new List<SpellUnit>(BASE_SLOTS);
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

        // Cambia el número de hechizos disponibles
        public void SetNumSlots(int n)
        {
            num_slots = BASE_SLOTS + n;
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
            spellSlots.AddRange(deck.GetSpellPool(num_slots));
            Events.OnGenerateSpellSlots.Invoke(spellSlots);
        }

        // Cambia el hechizo de la posición idx de la mesa
        private void ChangeSpellSlot(int idx)
        {
            spellSlots[idx] = deck.GetRandomSpell();
            Events.OnChangeSpellSlot.Invoke(idx, spellSlots[idx]);
        }

        #endregion


    }
}