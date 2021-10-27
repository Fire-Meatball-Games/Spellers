using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Runtime.CombatSystem.GUI
{
    public class SpellerStatsGUI : MonoBehaviour
    {
        #region Public variables

        [SerializeField] private TextMeshProUGUI txt_name;
        [SerializeField] private Slider healthSlider, shieldSlider;
        public Speller speller;

        #endregion

        #region Private fields



        #endregion

        private void Awake()
        {
            speller.Stats.OnChangeHealth += SetHealth;
            speller.Stats.OnChangeShield += SetShield;
            Init();
        }

        private void Init()
        {
            txt_name.text = speller.spellerName;
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