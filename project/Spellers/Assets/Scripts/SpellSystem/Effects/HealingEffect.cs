using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpellSystem
{
    [CreateAssetMenu(fileName = "Healing Effect", menuName = "Spellers/Spells/HealingEffect")]
    public class HealingEffect : Effect
    {
        [SerializeField] public int PointsBase;
        [SerializeField] public int pointslevel;
        [SerializeField] public Scale Scale;

        public override void Execute(SpellerStats user_stats, SpellerStats target_stats, int level)
        {
            float heal = PointsBase + pointslevel * level;

            if (Scale == Scale.Current)
            {
                heal *= target_stats.Health / 100f;
            }
            else if (Scale == Scale.Current)
            {
                heal *= (1f - (target_stats.Health / 100f));
            }

            target_stats.Health += (int)heal;
        }
    }
}
