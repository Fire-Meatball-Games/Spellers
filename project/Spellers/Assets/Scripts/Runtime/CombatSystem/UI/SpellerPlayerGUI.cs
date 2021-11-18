using UnityEngine;
using TMPro;
using UnityEngine.UI;
using CustomEventSystem;

namespace Runtime.CombatSystem
{
    namespace UI
    {
        public class SpellerPlayerGUI : MonoBehaviour
        {
            #region GUI Elements

            public Sprite regen_sprite, poison_sprite;

            public GameObject display;
            public TextMeshProUGUI txt_name;
            public Image icon;
            public Slider healthSlider;
            public TextMeshProUGUI num_shields;
            public Image img_shield;

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
                Events.OnChangePlayerHealth.AddListener(SetHealthBar);
                Events.OnChangePlayerShields.AddListener(SetShields);
                Events.OnChangePlayerAttack.AddListener(SetAttackLevel);
                Events.OnChangePlayerRegeneration.AddListener(SetRegenerationLevel);
                Events.OnChangePlayerSlots.AddListener(SetSlotsLevel);
                Events.OnChangePlayerOrder.AddListener(SetOrderLevel);
                Events.OnChangePlayerDifficulty.AddListener(SetDifficultyLevel);
                Events.OnBattleBegins.AddListener(ShowGUI);
            }

            private void OnDisable()
            {
                Events.OnChangePlayerHealth.RemoveListener(SetHealthBar);
                Events.OnChangePlayerShields.RemoveListener(SetShields);
                Events.OnChangePlayerAttack.RemoveListener(SetAttackLevel);
                Events.OnChangePlayerRegeneration.RemoveListener(SetRegenerationLevel);
                Events.OnChangePlayerSlots.RemoveListener(SetSlotsLevel);
                Events.OnChangePlayerOrder.RemoveListener(SetOrderLevel);
                Events.OnChangePlayerDifficulty.RemoveListener(SetDifficultyLevel);
                Events.OnBattleBegins.RemoveListener(ShowGUI);
            }

            public void SetUpPlayer(string playerName, Sprite sprite = null)
            {
                img_shield.gameObject.SetActive(false);
                regen_image.gameObject.SetActive(false);
                atk_image.gameObject.SetActive(false);
                slots_image.gameObject.SetActive(false);
                txt_name.text = playerName;
                icon.sprite = sprite ?? icon.sprite;
            }


            #endregion

            #region Private Methods
            private void SetHealthBar(int health)
            {
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

            private void SetAttackLevel(float lvl)
            {
                atk_image.gameObject.SetActive(lvl != 1f);
                atk_text.text = "x" + lvl;

            }

            private void SetSlotsLevel(int lvl)
            {
                slots_image.gameObject.SetActive(lvl != 0);
                slots_text.text = lvl > 0 ? "+" : "" + lvl;  
            }

            private void SetRegenerationLevel(int lvl)
            {
                regen_image.gameObject.SetActive(lvl != 0);
                regen_image.sprite = lvl > 0 ? regen_sprite : poison_sprite;
                regen_text.text = lvl > 0 ? "+" : "" + lvl;
            }

            private void SetOrderLevel(int lvl)
            {
                order_image.gameObject.SetActive(lvl != 0);
                order_text.text = lvl > 0 ? "+" : "" + lvl;
            }

            private void SetDifficultyLevel(int lvl)
            {
                diff_image.gameObject.SetActive(lvl != 0);
                diff_text.text = lvl > 0 ? "+" : "" + lvl;
            }

            private void ShowGUI()
            {
                display.SetActive(true);
            }
            #endregion
        }
    }
}