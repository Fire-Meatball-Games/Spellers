using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

namespace Runtime.CombatSystem
{
    namespace UI
    {
        public class SpellerGUI : MonoBehaviour
        {
            #region GUI Elements

            public TextMeshProUGUI txt_name;
            public Slider healthSlider;
            public Slider shieldSlider;
            #endregion

            #region Set up

            public void SetUp(Speller speller)
            {
                speller.Stats.OnChangeHealth += SetHealthBars;
                speller.Stats.OnChangeAtkLvlEvent += SetAtkLvl;
                speller.Stats.OnChangeDefLvlEvent += SetDefLvl;
                healthSlider.maxValue = speller.Stats.MaxHealth;
                shieldSlider.maxValue = 50;
                healthSlider.value = speller.Stats.MaxHealth;
                shieldSlider.value = 0;
                txt_name.text = speller.spellerName;
            }

            #endregion

            #region Private Methods

            private void SetHealthBars(int health, int shield)
            {
                healthSlider.value = health;
                shieldSlider.value = shield;
            }

            private void SetAtkLvl(int lvl)
            {
                //
            }

            private void SetDefLvl(int lvl)
            {
                //
            }

            #endregion
        }

    }

}