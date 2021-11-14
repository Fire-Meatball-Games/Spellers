using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Runtime
{
    public struct LevelData
    {
        public int max_score;
        public int stars;
    }


    public static class PlayerSettings
    {
        public static List<LevelData> levels = new List<LevelData>();
        public static string playerName;
        public static int lastLevelUnlocked;
    }

}