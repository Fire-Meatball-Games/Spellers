using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpellSystem
{
    [CreateAssetMenu(fileName = "CleanDebuffsEffect", menuName = "Spellers/Spells/CleanDebuffsEffect")]
    public class CleanDebuffsEffect : Effect
    {
        public override void Execute(Stats user_stats, Stats target_stats, int level)
        {
            if (target_stats.AttackLevel < 1) target_stats.AttackLevel = 1; target_stats.AttacklevelTurns = 0;
            if (target_stats.Regeneration < 0) target_stats.Regeneration = 0; target_stats.RegenerationTurns = 0;
            if (target_stats.SlotLevels < 0) target_stats.SlotLevels = 0; target_stats.SlotLevelTurns = 0;
            if (target_stats.Order < 0) target_stats.Order = 0; target_stats.OrderTurns = 0;
            if (target_stats.Difficulty < 0) target_stats.Difficulty = 0; target_stats.DifficultyTurns = 0;
        }
    }
}
