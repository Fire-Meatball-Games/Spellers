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

        [SerializeField] private TextMeshProUGUI txt_name, txt_atqLvl, txt_defLvl;
        [SerializeField] private Slider healthSlider, shieldSlider;
        public Speller speller;

        #endregion

        private void Awake()
        {
            
            Init();
        }

        private void Init()
        {
            speller.Stats.OnChangeHealth += SetHealthBars;
            speller.Stats.OnChangeAtkLvlEvent += SetAtkLvl;
            speller.Stats.OnChangeDefLvlEvent += SetDefLvl;
            txt_name.text = speller.spellerName;
            healthSlider.maxValue = 100;
            shieldSlider.maxValue = 150;
            healthSlider.value = 100;
            shieldSlider.value = 0;
        }

        private void SetHealthBars(int health, int shield)
        {
            healthSlider.value = health;
            shieldSlider.value = health + shield;
        }

        private void SetAtkLvl(int lvl)
        {
            txt_atqLvl.text = "Atk " + lvl;
        }

        private void SetDefLvl(int lvl)
        {
            txt_defLvl.text = "Def " + lvl;
        }

    }

}