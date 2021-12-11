using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Levels
{
    [CreateAssetMenu(fileName = "Level", menuName = "Spellers/Game/QuickGame", order = 0)]
    public class QuickGameSettings : BaseGameSettings
    {        
        [SerializeField] private int points_per_win;

        public int Points_per_win { get => points_per_win; }
    }
}

