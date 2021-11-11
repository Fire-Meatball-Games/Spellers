using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpellSystem
{
    [CreateAssetMenu(fileName = "RegenerationEffect", menuName = "Spellers/Spells/RegenerationEffect")]
    public class RegenerationEffect : Effect
    {
        [SerializeField] public int PointsBase;
        [SerializeField] public int Pointslevel;
        [SerializeField] public int TurnsBase;
        [SerializeField] public int Turnslevel;

        public override void Execute(SpellerStats user_stats, SpellerStats target_stats, int level)
        {
            int points = PointsBase + Pointslevel * level;
            int turns = TurnsBase + Turnslevel * level;
            if (target_stats.Regeneration * points < 0) target_stats.buffer.regenerationTurns = 0;
            target_stats.buffer.regeneration += points;
            target_stats.buffer.regenerationTurns += turns;
        }
    }
}
