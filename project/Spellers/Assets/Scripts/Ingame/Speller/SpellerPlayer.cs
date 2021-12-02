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
        public SpellTable table;
        public SpellBoard board;

        #endregion

        #region Private Fields

        private SpellDeck deck;

        #endregion

        #region Initalization
        public override void SetUp()
        {
            table = new SpellTable(deck);
            board = new SpellBoard();

            Stats.OnChangeHealthEvent += (n) => Events.OnChangePlayerHealth.Invoke(n);
            Stats.OnChangeShieldsEvent += (n) => Events.OnChangePlayerShields.Invoke(n);
            Stats.OnChangeAttackEvent += (n) => Events.OnChangePlayerAttack.Invoke(n);
            Stats.OnChangeRegenerationEvent += (n) => Events.OnChangePlayerRegeneration.Invoke(n);
            Stats.OnChangeSlotLevelsEvent += (n) => Events.OnChangePlayerSlots.Invoke(n);
            Stats.OnChangeOrderEvent += (n) => Events.OnChangePlayerOrder.Invoke(n);
            Stats.OnChangeDifficultyEvent += (n) => Events.OnChangePlayerDifficulty.Invoke(n);

            Stats.OnChangeAttackEvent += (_) => Events.OnChangeStat.Invoke();
            Stats.OnChangeRegenerationEvent += (_) => Events.OnChangeStat.Invoke();
            Stats.OnChangeOrderEvent += (_) => Events.OnChangeStat.Invoke();
            Stats.OnChangeDifficultyEvent += (_) => Events.OnChangeStat.Invoke();

            Stats.OnChangeSlotLevelsEvent += table.SetNumSlots;
            Stats.OnChangeOrderEvent += board.SetOrderLevel;           

            Stats.OnDefeatEvent += () => Events.OnDefeatPlayer.Invoke();

            table.Initialize();
        }

        private void OnEnable()
        {
            Events.OnSetTimer.AddListener(StartTimerCorroutine);
            Events.OnCompleteWord.AddListener(StopAllCoroutines);
            Events.OnFailSpell.AddListener(StopAllCoroutines);

            Events.OnCompleteStrengthMinigame.AddListener(Stats.CleanAttackDebuff);
            Events.OnCompletePoisonMinigame.AddListener(Stats.CleanRegenerationDebuff);
            Events.OnCompleteBlindMinigame.AddListener(Stats.CleanOrderDebuff);
            Events.OnCompleteDifficultyMinigame.AddListener(Stats.CleanDifficultyDebuff);
            Events.OnFailSpell.AddListener(Stats.CompleteTurn);
        }

        private void OnDisable()
        {
            Events.OnSetTimer.RemoveListener(StartTimerCorroutine);
            Events.OnCompleteWord.RemoveListener(StopAllCoroutines);
            Events.OnFailSpell.RemoveListener(StopAllCoroutines);

            Events.OnCompleteStrengthMinigame.RemoveListener(Stats.CleanAttackDebuff);
            Events.OnCompletePoisonMinigame.RemoveListener(Stats.CleanRegenerationDebuff);
            Events.OnCompleteBlindMinigame.RemoveListener(Stats.CleanOrderDebuff);
            Events.OnCompleteDifficultyMinigame.RemoveListener(Stats.CleanDifficultyDebuff);
            Events.OnFailSpell.RemoveListener(Stats.CompleteTurn);
        }
        #endregion


        #region Public methods

        public void SetDeck(SpellDeck deck)
        {
            this.deck = deck;
        }
        // Selecciona el hechizo en la posici�n idx de la mesa.
        // Activa el tablero correspondiente al tipo de hechizo seleccionado

        public void SelectSpell(int idx)
        {
            SpellSystem.SpellUnit spellUnit = table.SelectSpellSlot(idx);
            int level = spellUnit.lvl;
            int power = spellUnit.spell.Power;
            int wordLength = 2 + (power - 1) + level;
            int boardDimension = 2 + level;
            int ticks = 500  + 250 * level; // tick = 0.02s
            board.GenerateBoard(wordLength, boardDimension, ticks);            
        }

        // Pulsa la tecla (x, y) del tablero de juego

        public void OnKey(int column, int row)
        {
            board.CheckCharacterKey(column, row);
        }

        // Seleccionar un objetivo

        public void SetTarget(SpellerNPC target, int idx)
        {
            this.target = target;
            Events.OnSelectTarget.Invoke(idx);
        }
        #endregion

        #region Private Methods

        protected override SpellSystem.SpellUnit GetActiveSpell()
        {
            return table.GetSelectedSpell();
        }

        protected override void UseSpell(SpellSystem.SpellUnit spell)
        {
            Events.OnPlayerUseSpell.Invoke();
            base.UseSpell(spell);
        }

        private void StartTimerCorroutine(int ticks)
        {
            IEnumerator timerCorroutine = board.TimerCorroutine(ticks);
            StartCoroutine(timerCorroutine);
        }

        #endregion
    }
}
