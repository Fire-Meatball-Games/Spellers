using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

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

        public delegate void OnGenerateBoardDelegate(char[] keys, int dim, string word);
        public event OnGenerateBoardDelegate OnGenerateBoardEvent;
        public delegate void OnHitKeyDelegate(int id);
        public event OnHitKeyDelegate OnHitKeyEvent;
        public delegate void OnFailKeyDelegate();
        public event OnFailKeyDelegate OnFailKeyEvent;
        public delegate void OnCompleteWordDelegate();
        public event OnCompleteWordDelegate OnCompleteWordEvent;

        #endregion

        #region Properties

        #endregion


        #region Public methods

        // MÉTODO PRINCIPAL
        // Genera los datos del tablero de juego a partir del hechizo seleccionado por el jugador.
        // Invoca un evento que hace que la interfaz del tablero se actualice.

        public void GenerateBoard(int lvl)
        {
            int wordSize = 2 + 2 * lvl;
            word = GenerateRandomWord(wordSize, CHARS);
            keyDimension = lvl + 2;
            keys = GenerateRandomKeys(keyDimension * keyDimension, word);
            currentCharIdx = 0;
            OnGenerateBoardEvent?.Invoke(keys, keyDimension, word);
        }

        // MÉTODO PRINCIPAL
        // Comprueba que la letra de la posicion = (x, y) es igual a la letra en la posicion actual de la palabra generada.

        public void CheckCharacterKey(int x, int y)
        {
            char pressedChar = GetCharAtPos(x, y);
            char currentChar = word[currentCharIdx];

            if(pressedChar == currentChar)
            {                
                currentCharIdx++;
                OnHitKeyEvent?.Invoke(y * keyDimension + x);
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

        // Genera array de letras aleatorias de longitud = length
        // El array contiene las letras de la palabra = word

        private char[] GenerateRandomKeys(int length, string word)
        {
            string s = RemoveIntersect(word, CHARS);
            string k = GenerateRandomWord(length - word.Length, s);
            string c = k + word;
            return Shuffle(c).ToArray();
        }

        
        // Genera una palabra aleatoria de longitud = length

        private string GenerateRandomWord(int length, string charset)
        {
            var random = new System.Random();
            var randomString = new string(Enumerable.Repeat(charset, length).Select(
                s => s[random.Next(s.Length)]).ToArray());
            return randomString;
        }

        // Mezcla las letras de una palabra.
        public static string Shuffle(string str)
        {
            char[] array = str.ToCharArray();
            var rng = new System.Random();
            int n = array.Length;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                var value = array[k];
                array[k] = array[n];
                array[n] = value;
            }
            return new string(array);
        }

        // Devuelve un array de caracteres con las letras de una palabra que no están en otro.
        public static string RemoveIntersect(string str, string chars)
        {
            string s = "";
            foreach (var character in chars)
            {
                if (!str.Contains(character))
                    s += character;
            }
            return s;
        }
        #endregion
    }
}