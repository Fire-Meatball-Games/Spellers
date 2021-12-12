using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SpellSystem;
using CustomEventSystem;

namespace Ingame
{
    public class SpellerPlayer : Speller
    {
        #region Public variables
        public SpellBook book;
        public Board board;

        #endregion

        #region Private Fields

        private SpellDeck deck;

        #endregion

        #region Initalization
        
        public void SetUp(SpellDeck deck)
        {
            this.deck = deck;
            book = new SpellBook(deck);
            Stats.OnChangeSlotLevelsEvent += book.SetNumSlots;

            board = new Board(this);
            Stats.EventTrigger += ()=> Events.ActiveHealGame.Invoke();
            Stats.OnChangeTimeEvent += board.SetTime;       
        }

        public override void Active()
        {
            book.Initialize();
        }

        private void OnEnable()
        {
            Events.OnCompleteStopWandGame.AddListener(StopWandEffect);
            Events.OnCompletePotionsGame.AddListener(PotionEffect);
        }

        private void OnDisable()
        {
            Events.OnCompleteStopWandGame.RemoveListener(StopWandEffect);
            Events.OnCompletePotionsGame.RemoveListener(PotionEffect);
        }
        #endregion


        #region Public methods

        // Selecciona el hechizo en la posición idx de la mesa.
        // Activa el tablero correspondiente al tipo de hechizo seleccionado
        public void SelectSpell(int idx)
        {
            SpellUnit spellUnit = book.SelectSpellSlot(idx);
            board.GenerateSpellGame(spellUnit);            
        }

        public override void OnUseSpell()
        {
            base.OnUseSpell();
            Events.OnPlayerUseSpell.Invoke();
        }

        #endregion

        #region Inherited Methods

        protected override SpellUnit GetActiveSpell()
        {
            return book.GetSelectedSpell();
        }

        #endregion

        #region GameEffects

        private void StopWandEffect() => Stats.AttackState.SetState(2,5);
        private void PotionEffect() => Stats.Health += 20;

        #endregion
    }
}
