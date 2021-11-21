using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SpellSystem;

namespace Runtime
{

    public static class PlayerSettings
    {
        public static List<int> levelScores = new List<int>();
        public static SpellDeck deck = new SpellDeck();

        public static int hat = 0;
        public static int body = 0;
        public static Sprite icon = default;

        public static string playerName;
        public static int lastLevelUnlocked = 0;

        public static void SetLevelScore(int levelIndex, int score)
        {
            score = Mathf.Clamp(score, 1, 3);

            if(levelIndex == levelScores.Count)
            {
                levelScores.Add(score);
                lastLevelUnlocked++;
            }
            else if(levelIndex < levelScores.Count)
            {
                levelScores[levelIndex] = Mathf.Max(score, levelScores[levelIndex]);
            }
        }
    }

}