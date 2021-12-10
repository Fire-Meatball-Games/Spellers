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
            target_stats.AttackState.ClearDebuff();
            target_stats.RegenerationState.ClearDebuff();
            target_stats.CardsState.ClearDebuff();
            target_stats.OrderState.ClearDebuff();
            target_stats.TimeState.ClearDebuff();
        }
    }
}
