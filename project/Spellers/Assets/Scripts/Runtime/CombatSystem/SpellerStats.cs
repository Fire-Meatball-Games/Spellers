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

        public delegate void OnChangeHealthEvent(int health, int shield);
        public event OnChangeHealthEvent OnChangeHealth;

        public delegate void OnDefeatDelegate();
        public event OnDefeatDelegate OnDefeatEvent;

        #endregion

        #region Properties

        public int Health
        {
            get => healthPoints;
            set
            {
                int clampedValue = Mathf.Clamp(value, 0, maxHealthPoints);
                if(clampedValue != healthPoints)
                {
                    healthPoints = clampedValue;
                    OnChangeHealth?.Invoke(healthPoints, shieldPoints);
                    if (healthPoints == 0)
                        OnDefeatEvent?.Invoke();
                }                
            }
        }

        public int Shield 
        {
            get => shieldPoints;
            set
            {
                int clampedValue = Mathf.Clamp(value, 0, maxShieldPoints);
                if(clampedValue != shieldPoints)
                {
                    shieldPoints = clampedValue;
                    OnChangeHealth?.Invoke(healthPoints, shieldPoints);
                }   
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
            if(n <= shieldPoints)
            {
                Shield -= n;
            }
            else
            {
                int damage = n - shieldPoints;
                Shield = 0;
                Health -= damage;
            }
        }
    }

}