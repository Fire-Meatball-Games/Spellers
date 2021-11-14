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
            public GameObject display;
            public TextMeshProUGUI txt_name;
            public Slider healthSlider;
            public TextMeshProUGUI num_shields;
            public Image img_shield;
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
                Events.OnBattleBegins.AddListener(ShowGUI);
            }

            private void OnDisable()
            {
                Events.OnChangePlayerHealth.RemoveListener(SetHealthBar);
                Events.OnChangePlayerShields.RemoveListener(SetShields);
                Events.OnBattleBegins.RemoveListener(ShowGUI);
            }

            public void SetUpPlayer(string playerName)
            {
                img_shield.gameObject.SetActive(false);
                txt_name.text = playerName;
                
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

            private void ShowGUI()
            {
                display.SetActive(true);
            }
            #endregion
        }
    }
}