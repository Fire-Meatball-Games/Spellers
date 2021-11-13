using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Runtime.CombatSystem.UI
{
    public abstract class Minigame : MonoBehaviour
    {
        public RectTransform game_area;
        public GameObject panel;
        public Button exit_button;

        public abstract void GenerateGame();
        public abstract void CompleteGame();

        public void Awake()
        {
            exit_button.onClick.AddListener(ExitGame);
        }

        public void ExitGame()
        {
            StopAllCoroutines();
            panel.SetActive(false);
        }

        public void EnterGame()
        {
            panel.SetActive(true);
            GenerateGame();
        }
    }
}
