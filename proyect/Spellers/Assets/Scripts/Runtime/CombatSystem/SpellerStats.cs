using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Runtime.CombatSystem
{
    [System.Serializable]
    public class SpellerStats
    {
        #region Fields

        private int healthPoints;
        private int shieldPoints;

        private readonly int maxHealthPoints;
        private readonly int maxShieldPoints;

        public delegate void OnChangeHealthEvent(int health);
        public event OnChangeHealthEvent OnChangeHealth;

        public delegate void OnChangeShieldEvent(int shield);
        public event OnChangeShieldEvent OnChangeShield;

        #endregion

        #region Properties

        public int Health
        {
            get => healthPoints;
            set
            {
                int clampedValue = Mathf.Clamp(value, 0, maxHealthPoints);
                healthPoints = clampedValue;
                OnChangeHealth?.Invoke(healthPoints);
            }
        }

        private int Shield
        {
            get => shieldPoints;
            set
            {
                int clampedValue = Mathf.Clamp(value, 0, maxShieldPoints);
                shieldPoints = clampedValue;
                OnChangeShield?.Invoke(shieldPoints);
    
            }
        }

        public int MaxHealth => maxHealthPoints;
        public int MaxShield => maxShieldPoints;

        #endregion

        public SpellerStats(int health, int maxShield = 50)
        {
            maxHealthPoints = health;
            maxShieldPoints = maxShield;
            healthPoints = health;
            shieldPoints = 0;
        }


        public void GetDamage(int n)
        {
            Health -= n;
        }
    }

}