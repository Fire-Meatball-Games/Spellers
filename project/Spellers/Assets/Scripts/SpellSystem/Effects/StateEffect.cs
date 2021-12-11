using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpellSystem
{
    [CreateAssetMenu(fileName = "StateEffect", menuName = "Spellers/Spells/StateEffect")]
    public class StateEffect : Effect
    {
        public enum Type
        {
            AttackPower,
            Regeneration,
            Cards,
            Order,
            Time
        }

        [SerializeField] public Type type;
        [SerializeField] public int PointsBase;
        [SerializeField] public int Pointslevel;
        [SerializeField] public int TurnsBase;
        [SerializeField] public int Turnslevel;

        public override void Execute(Stats user_stats, Stats target_stats, int level)
        {
            int points = PointsBase + Pointslevel * level;
            int turns = TurnsBase + Turnslevel * level;
            switch (type)
            {
                case Type.AttackPower:  target_stats.AttackState.SetState(points, turns); break;
                case Type.Regeneration: target_stats.RegenerationState.SetState(points, turns); break;
                case Type.Cards:        target_stats.CardsState.SetState(points, turns); break;
                case Type.Order:        target_stats.OrderState.SetState(points, turns); break;
                case Type.Time:         target_stats.TimeState.SetState(points, turns); break;               
                default:  break;
            }
        }
    }

}
