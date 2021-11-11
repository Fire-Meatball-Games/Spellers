using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using CustomEventSystem;
using System;

namespace Runtime
{
    public class LevelInfoGUI : MonoBehaviour
    {
        public GameObject panel;
        public TextMeshProUGUI levelName_text;
        public TextMeshProUGUI levelIndex_text;
        public Button play_button;

        // Start is called before the first frame update
        void Awake()
        {
            panel?.SetActive(false);
            Events.OnSelectLevel.AddListener(UpdateUI);
            play_button.onClick.AddListener(FindObjectOfType<LevelSelector>().PlayLevel);
        }

        private void UpdateUI(int index)
        {
            panel?.SetActive(true);
            Level level = FindObjectOfType<LevelSelector>().SelectedLevel;
            levelName_text.text = level.levelname;
            levelIndex_text.text = "Nivel " + (index + 1);
        }
    } 
}
