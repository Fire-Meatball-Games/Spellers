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

            public Sprite regen_sprite, poison_sprite;

            public GameObject display;
            public TextMeshProUGUI txt_name;
            public Image icon;
            public Slider healthSlider;
            public TextMeshProUGUI num_shields;
            public Image img_shield;
            public int index;

            public Image atk_image;
            public Image regen_image;
            public Image slots_image;
            public Image order_image;
            public Image diff_image;


            public TextMeshProUGUI atk_text;
            public TextMeshProUGUI regen_text;
            public TextMeshProUGUI slots_text;
            public TextMeshProUGUI order_text;
            public TextMeshProUGUI diff_text;

            #endregion

            #region Set up

            private void Awake()
            {
                display.SetActive(false);
            }

            private void OnEnable()
            {
                Events.OnChangeEnemyHealth.AddListener(SetHealthBar);
                Events.OnChangeEnemyShields.AddListener(SetShields);
                Events.OnChangeEnemyAttack.AddListener(SetAttackLevel);
                Events.OnChangeEnemyRegeneration.AddListener(SetRegenerationLevel);
                Events.OnChangeEnemySlots.AddListener(SetSlotsLevel);
                Events.OnChangeEnemyOrder.AddListener(SetOrderLevel);
                Events.OnChangeEnemyDifficulty.AddListener(SetDifficultyLevel);
                Events.OnBattleBegins.AddListener(ShowGUI);
            }

            private void OnDisable()
            {
                Events.OnChangeEnemyHealth.RemoveListener(SetHealthBar);
                Events.OnChangeEnemyShields.RemoveListener(SetShields);
                Events.OnBattleBegins.RemoveListener(ShowGUI);
            }

            public void SetUpEnemy(int idx, string enemyName)
            {
                index = idx;
                img_shield.gameObject.SetActive(false);
                regen_image.gameObject.SetActive(false);
                atk_image.gameObject.SetActive(false);
                slots_image.gameObject.SetActive(false);
                txt_name.text = enemyName;
                
            }
            #endregion

            #region Private Methods
            private void ShowGUI()
            {
                display.SetActive(true);
            }


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


            private void SetAttackLevel(int idx, float lvl)
            {
                if (idx == index)
                {
                    atk_image.gameObject.SetActive(lvl != 1f);
                    atk_text.text = "x" + lvl; 
                }

            }

            private void SetSlotsLevel(int idx, int lvl)
            {
                if (idx == index)
                {
                    slots_image.gameObject.SetActive(lvl != 0);
                    slots_text.text = lvl > 0 ? "+" : "" + lvl; 
                }
            }

            private void SetRegenerationLevel(int idx, int lvl)
            {
                if (idx == index)
                {
                    regen_image.gameObject.SetActive(lvl != 0);
                    regen_image.sprite = lvl > 0 ? regen_sprite : poison_sprite;
                    regen_text.text = lvl > 0 ? "+" : "" + lvl; 
                }
            }

            private void SetOrderLevel(int idx, int lvl)
            {
                if (idx == index)
                {
                    order_image.gameObject.SetActive(lvl != 0);
                    order_text.text = lvl > 0 ? "+" : "" + lvl;
                }
            }

            private void SetDifficultyLevel(int idx, int lvl)
            {
                if (idx == index)
                {
                    diff_image.gameObject.SetActive(lvl != 0);
                    diff_text.text = lvl > 0 ? "+" : "" + lvl;
                }
            }

            #endregion

        }
    }
}