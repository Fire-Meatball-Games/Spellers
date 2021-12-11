using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpellSystem
{
    public enum Scale
    {
        Plane = 0,
        Current = 1,
        Missing = 2
    }

    public enum Target
    {
        Other = 0,
        Self = 1
    }

    public abstract class Effect : ScriptableObject
    {
        [SerializeField] public Target target;
        public void Apply(Stats user_stats, Stats target_stats, int level)
        {
            if (target == Target.Other) Execute(user_stats, target_stats, level);
            else if (target == Target.Self) Execute(user_stats, user_stats, level);
        }

        public abstract void Execute(Stats user_stats, Stats target_stats, int level);
    }
}
