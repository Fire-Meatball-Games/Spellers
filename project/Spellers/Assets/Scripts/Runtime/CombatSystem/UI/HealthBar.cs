using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Runtime.CombatSystem
{
    public class HealthBar : MonoBehaviour
    {
        public Slider healthSlider, shieldSlider;
        public Speller Speller;

        private void Awake()
        {
            Speller.Stats.OnChangeHealth += SetHealth;
            Speller.Stats.OnChangeShield += SetShield;
            Init();
        }

        private void Init()
        {
            healthSlider.maxValue = 100;
            shieldSlider.maxValue = 150;
            healthSlider.value = 100;
            shieldSlider.value = 0;
        }


        public void SetHealth(int health)
        {
            healthSlider.value = health;
        }

        public void SetShield(int shield)
        {
            shieldSlider.value = healthSlider.value + shield;
        }
    }

}