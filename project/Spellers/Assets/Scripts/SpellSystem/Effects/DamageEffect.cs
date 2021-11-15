using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpellSystem
{
    [CreateAssetMenu(fileName = "Damage Effect", menuName = "Spellers/Spells/DamageEffect")]
    public class DamageEffect : Effect
    {
        [SerializeField] public int PointsBase;
        [SerializeField] public int PointsLevel;
        [SerializeField] public int HitsBase;
        [SerializeField] public int HitsLevel;
        [SerializeField] public Scale Scale;

        public override void Execute(SpellerStats user_stats, SpellerStats target_stats, int level)
        {
            float damage = (PointsBase + PointsLevel * level) * user_stats.AttackLevel;
            int hits = HitsBase + HitsLevel * level;

            if (Scale == Scale.Current)
            {
                damage *= target_stats.Health / 100f;
            }
            else if (Scale == Scale.Current)
            {
                damage *= (1f - (target_stats.Health / 100f));
            }

            for (int i = 0; i < hits; i++)
            {
                target_stats.GetDamage((int)damage);
            }
        }
    }
}
