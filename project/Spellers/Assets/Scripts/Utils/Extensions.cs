using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Utils
{
    public static class Extensions
    {
        #region String Methods
        private const string CHARSET = "ABCDEFGHIKLMNOPQRSTUWZYZ";

        // Devuelve un string con las letras de una palabra que no están en otro.
        public static string RemoveIntersect(this string str, string chars)
        {
            string s = "";
            foreach (var character in chars)
            {
                if (!str.Contains(character.ToString()))
                    s += character;
            }
            return s;
        }

        // Mezcla las letras de una palabra.
        public static string Shuffle(this string str)
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

        // Genera array de letras aleatorias de longitud = length a partir de un charset
        // El array contiene las letras de la palabra = word
        // Las primeras n letras estarán ordenadas (n = orderedletters)

        public static char[] GenerateRandomKeys(int length, string word, int orderedletters, string charset = CHARSET)
        {
            string exclusivecharset = RemoveIntersect(word, charset);
            string randomset = GenerateRandomWord(length - word.Length, exclusivecharset);
            string head = word.Substring(0, Mathf.Min(orderedletters, word.Length));
            string tail = word.Substring(Mathf.Min(orderedletters, word.Length));
            string body = randomset + tail;
            string randomBody = Shuffle(body);
            return (head + randomBody).ToCharArray();
        }

        // Genera una palabra aleatoria de longitud = length

        public static string GenerateRandomWord(int length, string charset = CHARSET)
        {
            var random = new System.Random();
            var randomString = new string(Enumerable.Repeat(charset, length).Select(
                s => s[random.Next(s.Length)]).ToArray());
            return randomString;
        }
        #endregion
    }



}