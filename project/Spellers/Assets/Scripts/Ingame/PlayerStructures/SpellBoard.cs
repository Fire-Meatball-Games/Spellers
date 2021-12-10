using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Utils;
using CustomEventSystem;
using System;

namespace Ingame
{
    public class SpellBoard
    {
        #region Private Fields
        const string CHARS = "ABCDEFGHIKLMNOPQRSTUWXYZ";
        private string word;
        private char[] keys;
        private int keyDimension;
        private int currentCharIdx;
        private bool flip;
        private int orderedLetters;
        #endregion

        #region Public methods


        // M�TODO PRINCIPAL
        // Genera los datos del tablero de juego a partir del hechizo seleccionado por el jugador.
        // Invoca un evento que hace que la interfaz del tablero se actualice.

        public void GenerateBoard(int wordLength, int boardDimension, int ticks)
        {
            keyDimension = boardDimension;
            word = Extensions.GenerateRandomWord(wordLength, CHARS);
            keys = Extensions.GenerateRandomKeys(boardDimension * boardDimension, word, orderedLetters);
            currentCharIdx = 0;
            Events.OnGenerateBoard.Invoke(keys, boardDimension);
            Events.OnGenerateWord.Invoke(word, flip);
            StartTimer(ticks);

        }

        public void SetOrderLevel(int value)
        {            
            flip = value < 1;
            orderedLetters = Mathf.Max(0, value);
        }

        // M�TODO PRINCIPAL
        // Comprueba que la letra de la posicion = (x, y) es igual a la letra en la posicion actual de la palabra generada.

        public void CheckCharacterKey(int x, int y)
        {
            Events.OnSelectKey.Invoke(x, y);
            char pressedChar = GetCharAtPos(x, y);
            char currentChar = word[currentCharIdx];

            
            if(pressedChar == currentChar)
            {
                Events.OnCheckKey.Invoke(x, y, true);
                Events.OnHitkey.Invoke();
                currentCharIdx++;                
                if (currentCharIdx == word.Length)
                {
                    Events.OnCompleteWord.Invoke();
                }                    
            }
            else
            {               
                Events.OnFailSpell.Invoke();
            }
        }


        #endregion

        #region Private methods

        // Devuelve el caracter en la posici�n = (x,y) de la palabra generada

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
            Events.OnFailSpell.Invoke();
        }

        #endregion
    }
}