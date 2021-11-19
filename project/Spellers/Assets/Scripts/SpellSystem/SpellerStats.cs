using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpellSystem
{
    public class SpellerStats
    {
        #region Fields

        const int MAX_HEALTH = 100;
        const int MAX_SHIELDS = 6;

        private int health = MAX_HEALTH;
        private int shields = 0;

        private float attackMultiplier = 1f;
        private int attackMultiplierTurns = 0;

        private int regeneration;
        private int regenerationTurns = 0;

        private int slotLevels = 0;
        private int slotLevelTurns = 0;

        private int order = 0;
        private int orderTurns = 0;

        private int difficulty = 0;
        private int difficultyTurns = 0;

        public delegate void OnTriggerDelegate();
        public delegate void OnChangeStatDelegate(int value);      

        public delegate void OnChangeMultiplierDelegate(float value);

        public event OnTriggerDelegate OnDefeatEvent;
        public event OnTriggerDelegate OnGetHitEvent;
        public event OnChangeStatDelegate OnChangeHealthEvent;
        public event OnChangeStatDelegate OnChangeShieldsEvent;

        public event OnChangeMultiplierDelegate OnChangeAttackEvent;
        public event OnChangeStatDelegate OnChangeRegenerationEvent;
        public event OnChangeStatDelegate OnChangeSlotLevelsEvent;
        public event OnChangeStatDelegate OnChangeOrderEvent;
        public event OnChangeStatDelegate OnChangeDifficultyEvent;


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
                    attackMultiplier = Mathf.Clamp(value, 0.5f, 3f);
                    OnChangeAttackEvent?.Invoke(attackMultiplier);
                }
            }
        }

        public int Regeneration
        {
            get => regeneration;
            set
            {
                if (value != regeneration)
                {                    
                    regeneration = Mathf.Clamp(value, -10, 10);
                    OnChangeRegenerationEvent?.Invoke(regeneration);
                }
            }
        }

        public int Order { 
            get => order;
            set
            {
                order = Mathf.Clamp(value, -1, 3);
                OnChangeOrderEvent?.Invoke(order);
            } 
        }

        public int Difficulty { get => difficulty; set => difficulty = value; }

        public int SlotLevels
        {
            get => slotLevels;
            set
            {                
                slotLevels = Mathf.Clamp(value, -2, 3);
                OnChangeSlotLevelsEvent?.Invoke(slotLevels);
            }
        }

        // Turnos:
        public int AttacklevelTurns { get => attackMultiplierTurns; set => attackMultiplierTurns = Mathf.Max(0, value); }
        public int SlotLevelTurns { get => slotLevelTurns; set => slotLevelTurns = Mathf.Max(0, value); }
        public int OrderTurns { get => orderTurns; set => orderTurns = Mathf.Max(0, value); }
        public int DifficultyTurns { get => difficultyTurns; set => difficultyTurns = Mathf.Max(0, value); }        
        public int RegenerationTurns { get => regenerationTurns; set => regenerationTurns = Mathf.Max(0, value); }
        




        #endregion


        #region Public Methods

        // Completa un turno (lanzar o fallar un hechizo)
        public void CompleteTurn()
        {
            Health += Regeneration;

            SlotLevelTurns--;
            AttacklevelTurns--;
            OrderTurns--;
            DifficultyTurns--;
            RegenerationTurns--;

            if (RegenerationTurns == 0 && Regeneration != 0) Regeneration = 0;            
            if (AttacklevelTurns == 0 && AttackLevel != 1f) AttackLevel = 1f;
            if (OrderTurns == 0 && Order != 0) Order = 0;
            if (DifficultyTurns == 0 && Difficulty != 0) Difficulty = 0;
            if (SlotLevelTurns == 0 && SlotLevels != 0) SlotLevels = 0;

        }

        public void CleanAttackDebuff()
        {
            if (attackMultiplier < 0)
            {
                attackMultiplier = 0;
                attackMultiplierTurns = 0;
            }
        }

        public void CleanRegenerationDebuff()
        {
            if (regeneration < 0)
            {
                regeneration = 0;
                regenerationTurns = 0;
            }
        }

        public void CleanOrderDebuff()
        {
            if (order < 0)
            {
                order = 0;
                orderTurns = 0;
            }
        }


        // Recibe daño
        public void GetDamage(int damage)
        {
            OnGetHitEvent?.Invoke();
            if(Shields > 0)
                Shields--;
            else
                Health -= damage;
        }
        #endregion
    }

}