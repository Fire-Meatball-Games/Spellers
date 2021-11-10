using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using CustomEventSystem;

namespace Runtime.CombatSystem
{
    namespace UI
    {
        public class SpellerGUI : MonoBehaviour
        {
            #region GUI Elements
            public int index;
            public TextMeshProUGUI txt_name;
            public Slider healthSlider;
            public TextMeshProUGUI num_shields;
            public Image img_shield;
            #endregion

            #region Set up
            public void SetUpPlayer(string playerName)
            {
                img_shield.gameObject.SetActive(false);
                txt_name.text = playerName;
                Events.OnChangePlayerHealth.AddListener(SetHealthBar);
                Events.OnChangePlayerShields.AddListener(SetShields);
            }


            public void SetUpEnemy(int idx, string enemyName)
            {
                index = idx;
                img_shield.gameObject.SetActive(false);
                txt_name.text = enemyName;
                Events.OnChangeEnemyHealth.AddListener(SetHealthBar);
                Events.OnChangeEnemyShields.AddListener(SetShields);
            }

            #endregion

            #region Private Methods
            private void SetHealthBar(int health)
            {
                healthSlider.value = health;
            }
            private void SetHealthBar(int idx, int health)
            {
                if(idx == index)
                    healthSlider.value = health;               
            }

            private void SetShields(int shields)
            {
                num_shields.text = "" + shields;
                if(shields == 0)
                    img_shield.gameObject.SetActive(false);
                else
                    img_shield.gameObject.SetActive(true);
            }
            private void SetShields(int idx, int shields)
            {
                if (idx == index)
                {
                    num_shields.text = "" + shields;
                    if (shields == 0)
                        img_shield.gameObject.SetActive(false);
                    else
                        img_shield.gameObject.SetActive(true);
                }                    
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