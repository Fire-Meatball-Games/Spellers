using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using CustomEventSystem;

namespace BattleManagement
{
    public class SpellerBattleGUI : MonoBehaviour
    {
        public GameObject beginPanel;
        public GameObject countdownPanel;
        public GameObject pausePanel;
        public GameObject endPanel;

        public TextMeshProUGUI txt_countdown;
        public TextMeshProUGUI txt_results;
        public TextMeshProUGUI txt_score;
        public Button start_button;
        public Button end_button;
        public Button pause_button;
        public Button continue_button;
        public Button exit_button;

        public Image player_icon;
        public List<Image> enemy_icons;
        public RectTransform vs_icon;

        private BattleManager battle;

        public void Awake()
        {            
            start_button.onClick.AddListener(StartCountdown);
            end_button.onClick.AddListener(Return);
            exit_button.onClick.AddListener(ExitGame);
            pause_button.onClick.AddListener(() => Pause());
            continue_button.onClick.AddListener(() => UnPause());

        }

        public void Start()
        {
            battle = FindObjectOfType<BattleManager>();
            UnPause();
            SetUpInitPanel();
            beginPanel.SetActive(true);
            endPanel.SetActive(false);

        }

        private void OnEnable()
        {
            Events.OnBattleEnds.AddListener(EnableEndPanel);
        }

        private void OnDisable()
        {
            Events.OnBattleEnds.RemoveListener(EnableEndPanel);
        }

        private void ExitGame()
        {
            Time.timeScale = 1f;
            
            // if (GameSettings.currentLevel == -1)
            //     GameController.instance.GoToMainMenu();
            // else
            // {
            //     GameSettings.currentLevel = -1;
            //     GameController.instance.GoToHistoryMode();
            // }
                

        }

        private void Return()
        {            
            // if(GameController.instance != null)
            // {
            //     if(GameSettings.currentLevel == PlayerSettings.lastLevelUnlocked)
            //     {
            //         PlayerSettings.lastLevelUnlocked++;
            //         Debug.Log("Desbloqueado el nivel " + PlayerSettings.lastLevelUnlocked);
            //     }
            // }

            // if (GameSettings.currentLevel == -1)
            //     GameController.instance.GoToMainMenu();
            // else
            // {
            //     GameSettings.currentLevel = -1;
            //     GameController.instance.GoToHistoryMode();
            // }

        }

        private void EnableEndPanel(bool victory)
        {
            endPanel.SetActive(true);
            txt_results.text = victory ? "�Has ganado!" : "�Has perdido!";
            txt_score.text = "";

            
        }

        public void Pause()
        {
            Time.timeScale = 0.0f;
            pausePanel.SetActive(true);
        }

        public void UnPause()
        {
            Time.timeScale = 1.0f;
            pausePanel.SetActive(false);
        }

        private void StartCountdown()
        {
            beginPanel.SetActive(false);
            countdownPanel.SetActive(true);
            StartCoroutine(CountdownCR());
        }

        private IEnumerator CountdownCR()
        {
            txt_countdown.text = "" + 3;
            yield return new WaitForSeconds(1f);
            txt_countdown.text = "" + 2;
            yield return new WaitForSeconds(1f);
            txt_countdown.text = "" + 1;
            yield return new WaitForSeconds(1f);
            txt_countdown.text = "Spell!";
            yield return new WaitForSeconds(1f);
            Events.OnEndCountDown.Invoke();
            countdownPanel.SetActive(false);
        }

        private void SetUpInitPanel()
        {
            // //int num_enemies = GameSettings.combatSettings.speller_Settings.Count;

            // player_icon.rectTransform.anchorMin = new Vector3(0.3f - 0.1f * num_enemies, 0f);
            // player_icon.rectTransform.anchorMax = new Vector3(0.3f - 0.1f * num_enemies + 0.2f, 1f);
            // //player_icon.sprite = PlayerSettings.icon;

            // vs_icon.anchorMin = player_icon.rectTransform.anchorMin + new Vector2(0.2f, 0f);
            // vs_icon.anchorMax = vs_icon.anchorMin + new Vector2(0.2f, 1f);

            // for (int i = 0; i < enemy_icons.Count; i++)
            // {
            //     int idx = i;
            //     enemy_icons[idx].gameObject.SetActive(false);
            // }
            // for (int i = 0; i < Mathf.Min(num_enemies, enemy_icons.Count); i++)
            // {
            //     int idx = i;
            //     enemy_icons[idx].gameObject.SetActive(true);
            //    // enemy_icons[idx].sprite = GameSettings.combatSettings.speller_Settings[idx].icon;
            //     enemy_icons[idx].rectTransform.anchorMin = vs_icon.anchorMin + (i+1) * new Vector2(0.2f, 0f);
            //     enemy_icons[idx].rectTransform.anchorMax = enemy_icons[idx].rectTransform.anchorMin + new Vector2(0.2f, 1f);
            // }
        }
    }

}