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
            //Stats.OnChangeOrderEvent += board.SetOrderLevel; 
            //Stats.OnChangeTimeEvent += board.SetTime;       
        }

        public override void Active()
        {
            book.Initialize();
        }

        private void OnEnable()
        {
            Events.OnCompleteStrengthMinigame.AddListener(Stats.CleanAttackDebuff);
            Events.OnCompletePoisonMinigame.AddListener(Stats.CleanRegenerationDebuff);
            Events.OnCompleteBlindMinigame.AddListener(Stats.CleanOrderDebuff);
            Events.OnCompleteDifficultyMinigame.AddListener(Stats.CleanDifficultyDebuff);
            Events.OnFailSpell.AddListener(Stats.CompleteTurn);
        }

        private void OnDisable()
        {
            Events.OnCompleteStrengthMinigame.RemoveListener(Stats.CleanAttackDebuff);
            Events.OnCompletePoisonMinigame.RemoveListener(Stats.CleanRegenerationDebuff);
            Events.OnCompleteBlindMinigame.RemoveListener(Stats.CleanOrderDebuff);
            Events.OnCompleteDifficultyMinigame.RemoveListener(Stats.CleanDifficultyDebuff);
            Events.OnFailSpell.RemoveListener(Stats.CompleteTurn);
        }
        #endregion


        #region Public methods

        // Selecciona el hechizo en la posición idx de la mesa.
        // Activa el tablero correspondiente al tipo de hechizo seleccionado
        public void SelectSpell(int idx)
        {
            SpellUnit spellUnit = book.SelectSpellSlot(idx);
            board.GenerateGame(spellUnit);            
        }

        #endregion

        #region Inherited Methods

        protected override SpellUnit GetActiveSpell()
        {
            return book.GetSelectedSpell();
        }

        protected override void UseSpell(SpellUnit spell)
        {
            Events.OnPlayerUseSpell.Invoke();
            base.UseSpell(spell);
        }

        #endregion
    }
}
