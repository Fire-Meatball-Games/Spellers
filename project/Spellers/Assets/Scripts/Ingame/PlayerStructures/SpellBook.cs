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
        public List<SpellUnit> spellUnits = new List<SpellUnit>(BASE_SLOTS);
        private SpellUnit selectedSpell;
        private int num_slots;
        #endregion

        #region Events
        public event Action OnUpdateSpellUnits = delegate{};

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
            ReloadSpells();
        }

        // Cambia el número de hechizos disponibles
        public void SetNumSlots(int n)
        {
            num_slots = BASE_SLOTS + n;
            ReloadSpells();
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
            }
            OnUpdateSpellUnits?.Invoke();
        }
        #endregion

        #region private Methods

        // Añade un hechizo
        #endregion


    }
}