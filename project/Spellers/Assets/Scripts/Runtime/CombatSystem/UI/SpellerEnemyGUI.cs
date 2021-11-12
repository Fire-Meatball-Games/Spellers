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
        public class SpellerEnemyGUI : MonoBehaviour
        {
            #region GUI Elements
            public GameObject display;
            public TextMeshProUGUI txt_name;
            public Slider healthSlider;
            public TextMeshProUGUI num_shields;
            public Image img_shield;
            public int index;
            #endregion

            #region Set up

            private void Awake()
            {
                display.SetActive(false);
            }

            public void SetUpEnemy(int idx, string enemyName)
            {
                index = idx;
                img_shield.gameObject.SetActive(false);
                txt_name.text = enemyName;
                Events.OnChangeEnemyHealth.AddListener(SetHealthBar);
                Events.OnChangeEnemyShields.AddListener(SetShields);
                Events.OnBattleBegins.AddListener(() => display.SetActive(true));
            }
            #endregion

            #region Private Methods
            private void SetHealthBar(int idx, int health)
            {
                if (idx == index)
                    healthSlider.value = health;
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

            #endregion

        }
    }
}