﻿using UnityEngine;
using System.Collections.Generic;
using SpellSystem;
using System;
using System.Linq;

namespace Runtime.CombatSystem
{
    [SerializeField]
    public class SpellTable
    {
        #region Fields 
        private const int NUM_SLOTS = 3;

        private SpellDeck deck;
        private List<Spell> spellSlots;
        private Spell selectedSpell;
        #endregion

        #region Events
        public delegate void OnChangeSlotEvent(int id, string spellInfo);
        public OnChangeSlotEvent OnChangeSlot;
        public delegate void OnSelectSlotEvent();
        public OnSelectSlotEvent OnSelectSlot;

        #endregion

        #region Constructor

        public SpellTable(SpellDeck deck)
        {
            this.deck = deck;
        }

        #endregion

        #region public Methods        

        // Selecciona el hechizo 
        public void SelectSpellSlot(int idx)
        {
            selectedSpell = spellSlots[idx];
            ChangeSpellSlot(idx);
            OnSelectSlot?.Invoke();
        }

        // Devuelve el hechizo seleccionado
        public Spell GetSelectedSpell()
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
            spellSlots = new List<Spell>(deck.spells.OrderBy(x => rand.Next()).Take(NUM_SLOTS));
            for (int i = 0; i < NUM_SLOTS; i++)
            {
                OnChangeSlot?.Invoke(i, spellSlots[i].ToString());
            }
        }

        // Cambia el hechizo de la posición idx de la mesa
        private void ChangeSpellSlot(int idx)
        {
            spellSlots[idx] = deck.spells[new System.Random().Next(deck.spells.Count)];
            OnChangeSlot?.Invoke(idx, spellSlots[idx].ToString());
        }

        #endregion


    }
}