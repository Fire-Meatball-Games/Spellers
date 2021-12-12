using UnityEngine;
using System.Collections.Generic;
using SpellSystem;
using CustomEventSystem;
using System.Linq;
using System;

namespace Ingame
{
    // Define los hechizos que puede usar el jugador. Genera pools aleatorias de hechizos a partir del mazo del jugador.
    public class SpellBook
    {
        private static readonly int BASE_SLOTS = 3;

        #region Private Fields         
        private SpellDeck deck;
        private List<SpellUnit> spellUnits = new List<SpellUnit>(BASE_SLOTS);
        private SpellUnit selectedSpell;
        private int num_slots;
        #endregion

        #region Events
        public event Action<SpellUnit, int> OnAddSpellUnit = delegate{};
        public event Action OnRemoveSpellUnit = delegate{};
        public event Action<SpellUnit, int> OnUpdateSpellUnit = delegate{};

        #endregion

        

        #region Constructor

        public SpellBook(SpellDeck deck)
        {
            this.deck = deck;
            spellUnits = new List<SpellUnit>();
            num_slots = BASE_SLOTS;
        }

        #endregion

        #region public Methods        

        // Selecciona el hechizo 
        public SpellUnit SelectSpellSlot(int idx)
        {
            selectedSpell = spellUnits[idx];
            ReloadSpells();
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

        // Cambia el número de hechizos disponibles
        public void SetNumSlots(int n)
        {
            num_slots = BASE_SLOTS + n;
        }

        // Genera una nueva pool de hechizos:
        public void ReloadSpells()
        {
            List<SpellUnit> randomPool = deck.GetSpellPool(num_slots);
            spellUnits = randomPool;
            for (var i = 0; i < spellUnits.Count; i++)
            {
                int idx = i;
                SpellUnit unit = spellUnits[idx];
                OnUpdateSpellUnit?.Invoke(unit, idx);
            }
        }
        #endregion

        #region private Methods

        // Coloca 3 hechizos aleatorios del mazo del jugador a la mesa
        private void GenerateSpellSlots()
        {
            List<SpellUnit> randomPool = deck.GetSpellPool(num_slots);
            spellUnits = randomPool;
            for (var i = 0; i < spellUnits.Count; i++)
            {
                int idx = i;
                SpellUnit unit = spellUnits[idx];
                OnAddSpellUnit?.Invoke(unit, idx);
            }
        }

        // Cambia el hechizo de la posición idx de la mesa
        private void ChangeSpellSlot(int idx)
        {
            SpellUnit unit = deck.GetRandomSpell();
            spellUnits[idx] = unit;
            OnUpdateSpellUnit?.Invoke(unit, idx);
        }

        // Añade un hechizo
        private void AddSlot()
        {
            SpellUnit unit = deck.GetRandomSpell();
            spellUnits.Add(unit);
            OnAddSpellUnit?.Invoke(unit, spellUnits.Count - 1);
        }

        // Borra un hechizo
        private void RemoveLastSlot()
        {            
            spellUnits.RemoveAt(num_slots - 1);
            OnRemoveSpellUnit.Invoke();
        }
        #endregion


    }
}