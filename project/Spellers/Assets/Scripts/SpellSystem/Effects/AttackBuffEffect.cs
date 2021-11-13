using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpellSystem
{
    [CreateAssetMenu(fileName = "AttackBuffEffect", menuName = "Spellers/Spells/AttackEffect")]
    public class AttackBuffEffect : Effect
    {
        [SerializeField] public float PointsBase;
        [SerializeField] public float PointsLevel;
        [SerializeField] public int TurnsBase;
        [SerializeField] public int Turnslevel;

        public override void Execute(SpellerStats user_stats, SpellerStats target_stats, int level)
        {
            float points = PointsBase + PointsLevel * level;
            int turns = TurnsBase + Turnslevel * level;
            if (target_stats.AttackLevel * points < 0) target_stats.AttacklevelTurns = 0;
            target_stats.AttackLevel += points;
            target_stats.AttacklevelTurns += turns;
        }
    }
}
