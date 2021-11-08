using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Utils;

namespace Runtime.CombatSystem
{
    public class SpellBoard
    {
        #region Fields
        const string CHARS = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        private string word;
        private char[] keys;
        private int keyDimension;
        private int currentCharIdx;

        #endregion

        #region Properties
        public delegate void OnGenerateBoardDelegate(char[] keys, int dim, string word);        
        public delegate void OnHitKeyDelegate(int id, int currentChar);        
        public delegate void OnFailKeyDelegate();        
        public delegate void OnCompleteWordDelegate();
        public delegate void OnTimerDelegate(int ticks);

        public event OnHitKeyDelegate OnHitKeyEvent;
        public event OnFailKeyDelegate OnFailKeyEvent;
        public event OnGenerateBoardDelegate OnGenerateBoardEvent;
        public event OnCompleteWordDelegate OnCompleteWordEvent;
        public event OnTimerDelegate OnTimerStartEvent;
        public event OnTimerDelegate OnTimerTickEvent;

        #endregion


        #region Public methods

        // MÉTODO PRINCIPAL
        // Genera los datos del tablero de juego a partir del hechizo seleccionado por el jugador.
        // Invoca un evento que hace que la interfaz del tablero se actualice.

        public void GenerateBoard(int lvl)
        {
            int wordSize = 2 + 2 * lvl;
            word = Extensions.GenerateRandomWord(wordSize, CHARS);
            keyDimension = lvl + 2;
            keys = Extensions.GenerateRandomKeys(keyDimension * keyDimension, word);
            currentCharIdx = 0;
            OnGenerateBoardEvent?.Invoke(keys, keyDimension, word);
            
            // Calculo del tiempo dependiendo del hechizo y el nivel:
            // TO DO:
            int ticks = 50 * (4 + 4 * lvl);
            StartTimer(ticks);

        }

        // MÉTODO PRINCIPAL
        // Comprueba que la letra de la posicion = (x, y) es igual a la letra en la posicion actual de la palabra generada.

        public void CheckCharacterKey(int x, int y)
        {
            char pressedChar = GetCharAtPos(x, y);
            char currentChar = word[currentCharIdx];

            if(pressedChar == currentChar)
            {
                OnHitKeyEvent?.Invoke(y * keyDimension + x, currentCharIdx);
                currentCharIdx++;                
                if (currentCharIdx == word.Length)
                {
                    OnCompleteWordEvent?.Invoke();
                }
                    
            }
            else
            {
                OnFailKeyEvent?.Invoke();
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
            OnTimerStartEvent?.Invoke(ticks);
        }

        public IEnumerator TimerCorroutine(int ticks)
        {
            for(int i = 0; i < ticks; i++)
            {
                yield return new WaitForFixedUpdate();
                OnTimerTickEvent(i);
                Debug.Log("Timer :" + i);
            }
        }

        #endregion
    }
}