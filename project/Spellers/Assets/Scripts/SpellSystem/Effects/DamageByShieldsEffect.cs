using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpellSystem
{
    [CreateAssetMenu(fileName = "DamageByShields", menuName = "Spellers/Spells/DamageByshields")]
    public class DamageByShieldsEffect : Effect
    {
        [SerializeField] public int DamagePerShield;
        public override void Execute(Stats user_stats, Stats target_stats, int level)
        {
           int shields = user_stats.Shields;
           for (int i = 0; i < shields; i++)
           {
               target_stats.GetDamage(DamagePerShield);
           }
        }
    }
}
