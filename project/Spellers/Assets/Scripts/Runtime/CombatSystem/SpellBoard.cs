using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Utils;
using CustomEventSystem;

namespace Runtime.CombatSystem
{
    public class SpellBoard
    {
        #region Private Fields
        const string CHARS = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        private string word;
        private char[] keys;
        private int keyDimension;
        private int currentCharIdx;

        #endregion

        #region Public methods

        // MÉTODO PRINCIPAL
        // Genera los datos del tablero de juego a partir del hechizo seleccionado por el jugador.
        // Invoca un evento que hace que la interfaz del tablero se actualice.

        public void GenerateBoard(int wordLength, int boardDimension, int ticks)
        {
            keyDimension = boardDimension;
            word = Extensions.GenerateRandomWord(wordLength, CHARS);
            keys = Extensions.GenerateRandomKeys(boardDimension * boardDimension, word);
            currentCharIdx = 0;
            Events.OnGenerateBoard.Invoke(keys, boardDimension, word);             

            StartTimer(ticks);

        }

        // MÉTODO PRINCIPAL
        // Comprueba que la letra de la posicion = (x, y) es igual a la letra en la posicion actual de la palabra generada.

        public void CheckCharacterKey(int x, int y)
        {
            Events.OnSelectKey.Invoke(x, y);
            char pressedChar = GetCharAtPos(x, y);
            char currentChar = word[currentCharIdx];
            
            if(pressedChar == currentChar)
            {
                Events.OnCheckKey.Invoke(x, y, true);                
                currentCharIdx++;                
                if (currentCharIdx == word.Length)
                {
                    Events.OnCompleteWord.Invoke();
                }                    
            }
            else
            {
                Events.OnCheckKey.Invoke(x, y, false);
            }
        }


        #endregion

        #region Private methods

        // Devuelve el caracter en la posición = (x,y) de la palabra generada

        private char GetCharAtPos(int x, int y)
        {
            int id = y * keyDimension + x;
            return keys[id];
        } 

        private void StartTimer(int ticks)
        {
            Events.OnSetTimer.Invoke(ticks);
        }

        public IEnumerator TimerCorroutine(int ticks)
        {
            for(int i = 0; i < ticks; i++)
            {
                yield return new WaitForFixedUpdate();
                Events.OnUpdateTimer.Invoke(i);
            }
        }

        #endregion
    }
}