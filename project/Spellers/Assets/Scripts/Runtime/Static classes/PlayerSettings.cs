using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SpellSystem;

namespace Runtime
{

    public static class PlayerSettings
    {
        public static List<int> levelScores = new List<int>();
        public static SpellDeck deck;

        public static string playerName;
        public static int lastLevelUnlocked = 2;

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