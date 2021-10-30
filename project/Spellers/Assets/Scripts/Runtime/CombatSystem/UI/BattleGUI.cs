using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

namespace Runtime.CombatSystem.UI
{
    public class BattleGUI : MonoBehaviour
    {
        public GameObject beginPanel;
        public GameObject pausePanel;
        public GameObject endPanel;
        public TextMeshProUGUI txt_results;
        public Button end_button;
        public Button pause_button;
        public Button continue_button;
        public Button exit_button;
        public Battle battle;

        public void Awake()
        {
            battle.OnBeginBattle += DisableBeginPanel;
            battle.OnEndBattle += EnableBeginPanel;
            end_button.onClick.AddListener(() => SceneManager.LoadScene(0));
            pause_button.onClick.AddListener(() => Pause());
            continue_button.onClick.AddListener(() => UnPause());
            exit_button.onClick.AddListener(() => SceneManager.LoadScene(0));
        }

        public void Start()
        {
            beginPanel.SetActive(true);
            endPanel.SetActive(false);
        }

        private void DisableBeginPanel()
        {
            beginPanel.SetActive(false);
        }

        private void EnableBeginPanel()
        {
            endPanel.SetActive(true);
            if (battle.status == Battle.Status.lost)
                txt_results.text = "¡Has perdido!";
            else if (battle.status == Battle.Status.won)
                txt_results.text = "¡Has ganado!";
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