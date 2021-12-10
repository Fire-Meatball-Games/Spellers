using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpellSystem
{
    [CreateAssetMenu(fileName = "CleanBuffsEffect", menuName = "Spellers/Spells/CleanBuffsEffect")]
    public class CleanBuffsEffect : Effect
    {
        public override void Execute(Stats user_stats, Stats target_stats, int level)
        {
            target_stats.AttackState.ClearBuff();
            target_stats.RegenerationState.ClearBuff();
            target_stats.CardsState.ClearBuff();
            target_stats.OrderState.ClearBuff();
            target_stats.TimeState.ClearBuff();
        }
    }
}
