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
        public GameObject pausePanel;
        public GameObject endPanel;
        public TextMeshProUGUI txt_results;
        public Button start_button;
        public Button end_button;
        public Button pause_button;
        public Button continue_button;
        public Button exit_button;

        public void Awake()
        {
            Events.OnBattleBegins.AddListener(DisableBeginPanel);
            Events.OnBattleEnds.AddListener(EnableBeginPanel);
            start_button.onClick.AddListener(Events.OnBattleBegins.Invoke);
            end_button.onClick.AddListener(() => SceneManager.LoadScene(0));
            pause_button.onClick.AddListener(() => Pause());
            continue_button.onClick.AddListener(() => UnPause());
            exit_button.onClick.AddListener(() => SceneManager.LoadScene(0));
        }

        public void Start()
        {
            UnPause();
            beginPanel.SetActive(true);
            endPanel.SetActive(false);
        }

        private void DisableBeginPanel()
        {
            beginPanel.SetActive(false);
        }

        private void EnableBeginPanel(bool victory)
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
    }

}