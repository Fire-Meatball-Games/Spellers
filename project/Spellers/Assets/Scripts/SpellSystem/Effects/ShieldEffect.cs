using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpellSystem
{
    [CreateAssetMenu(fileName = "Shield Effect", menuName = "Spellers/Spells/ShieldEffect")]
    public class ShieldEffect : Effect
    {
        [SerializeField] public int PointsBase;
        [SerializeField] public int Pointslevel;

        public override void Execute(Stats user_stats, Stats target_stats, int level)
        {
            int shields = PointsBase + Pointslevel * level;
            target_stats.Shields += shields;
        }
    }
}
