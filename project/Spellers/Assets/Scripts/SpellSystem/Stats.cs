using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpellSystem
{
    [System.Serializable]
    public class Stats
    {
        public static readonly int MIN_HEALTH = 0;
        public static readonly int MAX_HEALTH = 100;
        public static readonly int MIN_SHIELDS = 0;
        public static readonly int MAX_SHIELDS = 6;
        public static readonly int MIN_ATKPOWER = -3;
        public static readonly int MAX_ATKPOWER = 3;
        public static readonly int MIN_REGENERATION = -3;
        public static readonly int MAX_REGENERATION = 3;
        public static readonly int MIN_CARDS = -2;
        public static readonly int MAX_CARDS = 3;
        public static readonly int MIN_ORDER = -1;
        public static readonly int MAX_ORDER = 3;
        public static readonly int MIN_TIME = -2;
        public static readonly int MAX_TIME = 3;

        #region Fields

        private bool eventTriggered;

        public event Action EventTrigger = delegate{};

        private int health = MAX_HEALTH;
        private int shields = 0;

        public State AttackState;
        public State RegenerationState;
        public State CardsState;
        public State OrderState;
        public State TimeState;

        public delegate void OnTriggerDelegate();
        public delegate void OnChangeStatDelegate(int value);     
        public delegate void OnChangeMultiplierDelegate(float value);

        public event Action OnDefeatEvent = delegate{};
        public event Action OnGetHitEvent = delegate{};
        public event Action<int> OnChangeHealthEvent = delegate{};
        public event Action<int> OnChangeShieldsEvent = delegate{};

        public event Action<int> OnChangeAttackEvent = delegate{};
        public event Action<int> OnChangeRegenerationEvent = delegate{};
        public event Action<int> OnChangeSlotLevelsEvent = delegate{};
        public event Action<int> OnChangeOrderEvent = delegate{};
        public event Action<int> OnChangeTimeEvent = delegate{};

        #endregion

        #region Properties

        public Stats() 
        {
            health = MAX_HEALTH;

            AttackState = new State(MIN_ATKPOWER, MAX_ATKPOWER, 0, OnChangeAttack);
            RegenerationState = new State(MIN_REGENERATION, MAX_REGENERATION, 0, OnChangeRegeneration);
            CardsState = new State(MIN_CARDS, MAX_CARDS, 0, OnChangeCards);
            OrderState = new State(MIN_ORDER, MAX_ORDER, 0, OnChangeOrder);
            TimeState = new State(MIN_TIME, MAX_TIME, 0, OnChangeTime);
        }

        private void OnChangeAttack(int n) =>  OnChangeAttackEvent.Invoke(n);
        private void OnChangeRegeneration(int n) =>  OnChangeRegenerationEvent.Invoke(n);
        private void OnChangeCards(int n) =>  OnChangeSlotLevelsEvent.Invoke(n);
        private void OnChangeOrder(int n) =>  OnChangeOrderEvent.Invoke(n);
        private void OnChangeTime(int n) =>  OnChangeTimeEvent.Invoke(n);

        public int Health
        {
            get => health;
            set
            {
                int clampedValue = Mathf.Clamp(value, MIN_HEALTH, MAX_HEALTH);
                if(clampedValue != health)
                {
                    health = clampedValue;
                    OnChangeHealthEvent?.Invoke(health);
                    Debug.Log("HEALTH = " + clampedValue);
                    if (health == 0) {
                        OnDefeatEvent?.Invoke(); 
                    }
                    else if (health < 40 && !eventTriggered)
                    {
                        EventTrigger?.Invoke();
                        eventTriggered = true;
                    }
                }                
            }
        }

        public int Shields 
        {
            get => shields;
            set
            {
                int clampedValue = Mathf.Clamp(value, MIN_SHIELDS, MAX_SHIELDS);
                if(clampedValue != shields)
                {
                    shields = clampedValue;
                    OnChangeShieldsEvent?.Invoke(shields);
                }   
            }
        }

        public float AttackMultiplier()
        {
            return 1f + AttackState.CurrentValue * 0.2f;
        }

       
        #endregion


        #region Public Methods

        // Completa un turno (lanzar o fallar un hechizo)
        public void CompleteTurn()
        {
            Health += RegenerationState.CurrentValue * 5;          

            AttackState.OnCompleteTurn();
            RegenerationState.OnCompleteTurn();
            CardsState.OnCompleteTurn();
            OrderState.OnCompleteTurn();
            TimeState.OnCompleteTurn();

        }

        // Recibe dañoo
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