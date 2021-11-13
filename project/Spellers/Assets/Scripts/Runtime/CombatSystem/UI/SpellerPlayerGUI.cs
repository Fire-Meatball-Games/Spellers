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

            public void SetUpPlayer(string playerName)
            {
                img_shield.gameObject.SetActive(false);
                txt_name.text = playerName;
                Events.OnChangePlayerHealth.AddListener(SetHealthBar);
                Events.OnChangePlayerShields.AddListener(SetShields);
                Events.OnBattleBegins.AddListener(() => display.SetActive(true));
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
            #endregion
        }
    }
}