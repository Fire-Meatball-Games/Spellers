using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Ingame.UI
{
    public class BoardGUI : MonoBehaviour
    {
        #region Inspector Fields
        [SerializeField] private RectTransform runeBoardLayout;
        [SerializeField] private RectTransform spellWordLayout;
        [SerializeField] private Button surrend_button;
        [SerializeField] private GameBoard gameBoard;

        [Header("Games")]

        [SerializeField] private TestGame testGame; 

        #endregion

        #region Private fields    
        private SpellerPlayer player;    
        private Board playerBoard;

        #endregion

        #region Public Methods

        public void SetUp(SpellerPlayer spellerPlayer)
        {
            player = spellerPlayer;
            playerBoard = player.board;
            playerBoard.OnGenerateGame += GenerateBoardGUI;
        }

        #endregion

        // Genera el tablero de juego con los datos del jugador:
        private void GenerateBoardGUI()
        {
            //testGame.SetSuccessListener();
            testGame.Generate();
        }


    }

}
