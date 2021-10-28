using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Runtime.CombatSystem.UI
{
    public class SpellerStatsGUI : MonoBehaviour
    {
        #region Public variables

        [SerializeField] private TextMeshProUGUI txt_name;
        [SerializeField] private Slider healthSlider, shieldSlider;
        public Speller speller;

        #endregion

        private void Awake()
        {
            speller.Stats.OnChangeHealth += SetHealthBars;
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


        public void SetHealthBars(int health, int shield)
        {
            healthSlider.value = health;
            shieldSlider.value = health + shield;

        }

    }

}