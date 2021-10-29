using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Runtime.CombatSystem
{
    [System.Serializable]
    public class SpellerStats
    {
        #region Fields
        const int MAX_STATE_LVL = 3;
        const int MIN_STATE_LVL = -3;

        private int healthPoints;
        private int shieldPoints;
        private int atkLvl;
        private int defLvl;

        private readonly int maxHealthPoints;
        private readonly int maxShieldPoints;

        public delegate void OnChangeHealthEvent(int health, int shield);
        public event OnChangeHealthEvent OnChangeHealth;

        public delegate void OnDefeatDelegate();
        public event OnDefeatDelegate OnDefeatEvent;

        public delegate void OnChangeStatDelegate(int lvl);
        public event OnChangeStatDelegate OnChangeAtkLvlEvent;
        public event OnChangeStatDelegate OnChangeDefLvlEvent;

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

        public int AttackLevel
        {
            get => atkLvl;
            set
            {
                int clampedValue = Mathf.Clamp(value, MIN_STATE_LVL, MAX_STATE_LVL);
                if(clampedValue != atkLvl)
                {
                    atkLvl = clampedValue;
                    OnChangeAtkLvlEvent?.Invoke(atkLvl);
                }
            }
        }

        public int DefenseLevel
        {
            get => defLvl;
            set
            {
                int clampedValue = Mathf.Clamp(value, MIN_STATE_LVL, MAX_STATE_LVL);
                if (clampedValue != defLvl)
                {
                    defLvl = clampedValue;
                    OnChangeDefLvlEvent?.Invoke(defLvl);
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