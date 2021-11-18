using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using CustomEventSystem;

namespace Runtime.CombatSystem.GUI
{
    public class SpellerBattleGUI : MonoBehaviour
    {
        public GameObject beginPanel;
        public GameObject countdownPanel;
        public GameObject pausePanel;
        public GameObject endPanel;

        public TextMeshProUGUI txt_countdown;
        public TextMeshProUGUI txt_results;
        public Button start_button;
        public Button end_button;
        public Button pause_button;
        public Button continue_button;
        public Button exit_button;

        public void Awake()
        {            
            start_button.onClick.AddListener(StartCountdown);
            end_button.onClick.AddListener(Return);
            pause_button.onClick.AddListener(() => Pause());
            continue_button.onClick.AddListener(() => UnPause());

        }

        public void Start()
        {
            UnPause();
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

        private void Return()
        {
            if(GameSettings.currentLevel < 0)
                SceneManager.LoadScene(0);
            else
                SceneManager.LoadScene(1);
            if(GameController.instance != null)
            {
                if(GameSettings.currentLevel == PlayerSettings.lastLevelUnlocked)
                {
                    PlayerSettings.lastLevelUnlocked++;
                    Debug.Log("Desbloqueado el nivel " + PlayerSettings.lastLevelUnlocked);
                }
            }
            GameSettings.currentLevel = -1;
        }

        private void EnableEndPanel(bool victory)
        {
            endPanel.SetActive(true);
            txt_results.text = victory ? "¡Has ganado!" : "¡Has perdido!";
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
    }

}