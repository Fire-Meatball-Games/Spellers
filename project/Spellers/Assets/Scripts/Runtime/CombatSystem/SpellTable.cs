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
        private List<SpellSystem.SpellUnit> spellSlots = new List<SpellSystem.SpellUnit>(BASE_SLOTS);
        private SpellSystem.SpellUnit selectedSpell;
        private int num_slots = BASE_SLOTS;
        #endregion

        #region Constructor

        public SpellTable(SpellDeck deck)
        {
            this.deck = deck;
        }

        public int NumSlots
        {
            get => num_slots;
            set
            {

                value = Mathf.Clamp(value, 1, 6);
                if(value < num_slots)
                {
                    for (int i = 0; i < num_slots - value; i++)
                        RemoveLastSlot();
                }
                else if(value > num_slots)
                {
                    for (int i = 0; i < value - num_slots; i++)
                        AddSlot();
                }
                num_slots = value;
            }
        }

        #endregion

        #region public Methods        

        // Selecciona el hechizo 
        public SpellSystem.SpellUnit SelectSpellSlot(int idx)
        {
            selectedSpell = spellSlots[idx];
            ChangeSpellSlot(idx);
            Events.OnSelectSpellSlot.Invoke(idx);
            return selectedSpell;
        }

        // Devuelve el hechizo seleccionado
        public SpellSystem.SpellUnit GetSelectedSpell()
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
            NumSlots = BASE_SLOTS + n;
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

        // Añade un hechizo
        private void AddSlot()
        {
            int idx = spellSlots.Count;
            spellSlots.Add(deck.GetRandomSpell());
            Events.OnGenerateSpellSlots.Invoke(spellSlots);
        }

        // Borra un hechizo
        private void RemoveLastSlot()
        {
            int idx = spellSlots.Count - 1;
            spellSlots.RemoveAt(idx);
            Events.OnGenerateSpellSlots.Invoke(spellSlots);
        }


        #endregion


    }
}