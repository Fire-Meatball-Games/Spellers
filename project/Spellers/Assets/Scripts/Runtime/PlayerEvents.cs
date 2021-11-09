using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CustomEventSystem;

namespace Runtime
{
    public class PlayerEvents : MonoBehaviour
    {
        private int total_spells;
        private int streak_spells;

        public void Awake()
        {
            Events.OnPlayerUseSpell.AddListener(() =>
            {
                total_spells++;
                streak_spells++;
            });
            Events.OnCheckKey.AddListener((x, y, hit) =>
            {
                if (!hit)
                    streak_spells = 0;
            });
        }
    }

}