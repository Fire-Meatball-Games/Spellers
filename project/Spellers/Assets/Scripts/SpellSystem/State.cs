using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpellSystem
{      
    [System.Serializable]
    public class State
    {
        private int currentValue;
        private int turns;

        public readonly int minValue, maxValue, initialValue;

        public event Action<int> OnChangeValue = delegate{};

        public State(int minValue, int maxValue, int initialValue, Action<int> OnChangeValue)
        {
            this.minValue = minValue;
            this.maxValue = maxValue;
            this.initialValue = initialValue;
            this.OnChangeValue += OnChangeValue;
            this.currentValue = initialValue;
        }

        public int CurrentValue
        {
            get => currentValue;
            set 
            {
                int clampedValue = Mathf.Clamp(value, minValue, maxValue);
                if(clampedValue != currentValue)
                {
                    Debug.Log("Estado modificado");
                    currentValue = clampedValue;
                    OnChangeValue?.Invoke(currentValue);
                }
            }
        }

        public int Turns
        {
            get => turns;
            set
            {
                int adjustedValue = Mathf.Max(0, value);
                if(turns != adjustedValue)
                {
                    Debug.Log(turns + " !!!!!===== " + adjustedValue);
                    turns = adjustedValue;
                    if(turns == 0)
                    {
                        CurrentValue = initialValue;
                    }
                }
            }
        }

        public void SetState(int value, int turns)
        {
            CurrentValue += value;
            Turns = turns;

        }

        public void OnCompleteTurn()
        {
            Turns--;
        }

        public void ClearBuff()
        {
            if(currentValue > initialValue)
            {
                Turns = 0;
            }
        }

        public void ClearDebuff()
        {
            if(currentValue < initialValue)
            {
                Turns = 0;
            }
        }
    }

}
