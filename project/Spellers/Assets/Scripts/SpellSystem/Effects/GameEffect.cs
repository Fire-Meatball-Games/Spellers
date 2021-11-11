using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpellSystem
{
    [CreateAssetMenu(fileName = "GameEffect", menuName = "Spellers/Spells/GameEffect")]
    public class GameEffect : Effect
    {
        public enum Type
        {
            Slots = 0,
            Order = 1,
            Difficulty = 2
        }

        [SerializeField] public Type type;

        [SerializeField] public int PointsBase;
        [SerializeField] public int Pointslevel;
        [SerializeField] public int TurnsBase;
        [SerializeField] public int Turnslevel;

        public override void Execute(SpellerStats user_stats, SpellerStats target_stats, int level)
        {
            int points = PointsBase + Pointslevel * level;
            int turns = TurnsBase + Turnslevel * level;

            switch (type)
            {
                case Type.Slots:
                    if (target_stats.SlotLevels * points < 0) target_stats.buffer.slotLevelsTurns = 0;
                    target_stats.buffer.slotLevels += points;
                    target_stats.buffer.slotLevelsTurns += turns;
                    break;
                case Type.Order:
                    if (target_stats.Order * points < 0) target_stats.buffer.orderTurns = 0;
                    target_stats.buffer.order += points;
                    target_stats.buffer.orderTurns += turns;
                    break;
                case Type.Difficulty:
                    if (target_stats.Difficulty * points < 0) target_stats.buffer.difficultyTurns = 0;
                    target_stats.buffer.difficulty += points;
                    target_stats.buffer.difficultyTurns += turns;
                    break;
                default:
                    break;
            }
        }
    }
}