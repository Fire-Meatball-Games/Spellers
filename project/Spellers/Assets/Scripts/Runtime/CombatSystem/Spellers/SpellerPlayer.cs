using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SpellSystem;
using CustomEventSystem;

namespace Runtime.CombatSystem
{
    public class SpellerPlayer : Speller
    {
        #region Public variables
        public SpellTable table;
        public SpellBoard board;

        [SerializeField] List<Spell> spells;
        #endregion


        #region Initalization
        public void SetSettings(SpellDeck deck = null)
        {
            spellWand = FindObjectOfType<SpellWand>();
            SpellDeck playerDeck = deck ?? new SpellDeck(spells);
            table = new SpellTable(playerDeck);
            board = new SpellBoard();

            stats.OnChangeHealthEvent += (n) => Events.OnChangePlayerHealth.Invoke(n);
            stats.OnChangeShieldsEvent += (n) => Events.OnChangePlayerShields.Invoke(n);
            stats.OnChangeAttackEvent += (n) => Events.OnChangePlayerAttack.Invoke(n);
            stats.OnChangeRegenerationEvent += (n) => Events.OnChangePlayerRegeneration.Invoke(n);
            stats.OnChangeSlotLevelsEvent += (n) => Events.OnChangePlayerSlots.Invoke(n);
            stats.OnChangeOrderEvent += (n) => Events.OnChangePlayerOrder.Invoke(n);
            stats.OnChangeDifficultyEvent += (n) => Events.OnChangePlayerDifficulty.Invoke(n);
            
            stats.OnChangeSlotLevelsEvent += table.SetNumSlots;
            stats.OnChangeOrderEvent += board.SetOrderLevel;           

            stats.OnDefeatEvent += () => Events.OnDefeatPlayer.Invoke();

            table.Initialize();
        }

        private void OnEnable()
        {
            Events.OnSetTimer.AddListener(StartTimerCorroutine);
            Events.OnCompleteWord.AddListener(StopAllCoroutines);
            Events.OnFailSpell.AddListener(StopAllCoroutines);

            Events.OnCompleteStrengthMinigame.AddListener(stats.CleanAttackDebuff);
            Events.OnCompletePoisonMinigame.AddListener(stats.CleanRegenerationDebuff);
            Events.OnCompleteBlindMinigame.AddListener(stats.CleanOrderDebuff);
            Events.OnFailSpell.AddListener(stats.CompleteTurn);
        }

        private void OnDisable()
        {
            Events.OnSetTimer.RemoveListener(StartTimerCorroutine);
            Events.OnCompleteWord.RemoveListener(StopAllCoroutines);
            Events.OnFailSpell.RemoveListener(StopAllCoroutines);

            Events.OnCompleteStrengthMinigame.RemoveListener(stats.CleanAttackDebuff);
            Events.OnCompletePoisonMinigame.RemoveListener(stats.CleanRegenerationDebuff);
            Events.OnCompleteBlindMinigame.RemoveListener(stats.CleanOrderDebuff);
            Events.OnFailSpell.RemoveListener(stats.CompleteTurn);
        }
        #endregion


        #region Public methods

        // Selecciona el hechizo en la posición idx de la mesa.
        // Activa el tablero correspondiente al tipo de hechizo seleccionado

        public void SelectSpell(int idx)
        {
            SpellUnit spellUnit = table.SelectSpellSlot(idx);
            int level = spellUnit.lvl;
            int power = spellUnit.spell.power;
            int wordLength = 2 * (power % 2 + 1) + level + 1; // 4/5/6 para p1, 6/7/8 para p2, 8 para p3.
            int boardDimension = 2 + level;
            int ticks = 200  + 100 * level; // tick = 0.02s
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

        protected override SpellUnit GetActiveSpell()
        {
            return table.GetSelectedSpell();
        }

        protected override void UseSpell(SpellUnit spell)
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
