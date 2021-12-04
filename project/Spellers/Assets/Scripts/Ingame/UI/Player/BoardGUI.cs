using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using CustomEventSystem;

namespace Ingame.UI
{
    public class BoardGUI : SpellPlayerGUI
    {
        #region Inspector Fields
        [SerializeField] private RectTransform runeBoardLayout;
        [SerializeField] private RectTransform spellWordLayout;
        [SerializeField] private Button surrend_button;
        [SerializeField] private Slider time_slider;

        [Header("Games")]

        [SerializeField] private TestGame testGame; 
        [SerializeField] private RunestoneGame runestoneGame;

        #endregion

        #region Private fields    
 
        private Board playerBoard;
        private GameBoard currentGame;

        #endregion

        #region Public Methods

        public override void SetUp(SpellerPlayer spellerPlayer)
        {
            base.SetUp(spellerPlayer);
            playerBoard = player.board;
            playerBoard.OnGenerateGame += GenerateBoardGUI;
            InitializeGames();
        }

        #endregion

        // Genera el tablero de juego con los datos del jugador:

        public void GenerateBoardGUI(Board.GameType type, int difficulty, float time)
        {
            switch(type)
            {
                case Board.GameType.spell: runestoneGame.Generate(); break;
                default: break;
            }
                        
        }

        private void FailListener()
        {
            Events.OnFailGame.Invoke();
        }

        private void SuccessListener()
        {
            Events.OnCompleteGame.Invoke();
        }

        private void SurrendListener()
        {

        }

        private void InitializeGames()
        {
            runestoneGame.AddSuccessListener(SuccessListener);
            runestoneGame.AddFailListener(FailListener);
        }


    }

}
