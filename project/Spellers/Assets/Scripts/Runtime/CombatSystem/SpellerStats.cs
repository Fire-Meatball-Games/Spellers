using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Runtime.CombatSystem
{
    [System.Serializable]
    public class SpellerStats
    {
        #region Fields

        const int MAX_HEALTH = 100;
        const int MAX_SHIELDS = 6;

        private int health = MAX_HEALTH;
        private int shields = 0;
        private float attackMultiplier = 1f;
        private float defenseMultiplier = 1f;

        public delegate void OnDefeatDelegate();
        public delegate void OnChangeStatDelegate(int value);
        public delegate void OnChangeMultiplierDelegate(float value);
        public event OnDefeatDelegate OnDefeatEvent;
        public event OnChangeStatDelegate OnChangeHealthEvent;
        public event OnChangeStatDelegate OnChangeShieldsEvent;
        public event OnChangeMultiplierDelegate OnChangeAttackEvent;
        public event OnChangeMultiplierDelegate OnChangeDefenseEvent;



        #endregion

        #region Properties

        public SpellerStats() { }

        public int Health
        {
            get => health;
            set
            {
                int clampedValue = Mathf.Clamp(value, 0, MAX_HEALTH);
                if(clampedValue != health)
                {
                    health = clampedValue;
                    OnChangeHealthEvent?.Invoke(health);
                    if (health == 0)
                        OnDefeatEvent?.Invoke();
                }                
            }
        }

        public int Shields 
        {
            get => shields;
            set
            {
                int clampedValue = Mathf.Clamp(value, 0, MAX_SHIELDS);
                if(clampedValue != shields)
                {
                    shields = clampedValue;
                    OnChangeShieldsEvent?.Invoke(shields);
                }   
            }
        }

        public float AttackLevel
        {
            get => attackMultiplier;
            set
            {               
                if(value != attackMultiplier)
                {
                    attackMultiplier = value;
                    OnChangeAttackEvent?.Invoke(attackMultiplier);
                }
            }
        }

        public float DefenseLevel
        {
            get => defenseMultiplier;
            set
            {               
                if (value != defenseMultiplier)
                {
                    defenseMultiplier = value;
                    OnChangeDefenseEvent?.Invoke(defenseMultiplier);
                }                
            }
        }

        #endregion


        #region Public Methods
        public void GetDamage(int damage)
        {
            if(Shields > 0)
            {
                Shields--;
            }
            else
            { 
                Health -= damage;
            }
        }
        #endregion
    }

}