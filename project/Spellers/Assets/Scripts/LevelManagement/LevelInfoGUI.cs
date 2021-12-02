using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using CustomEventSystem;
using System;
using UnityEngine.SceneManagement;

namespace Runtime
{
    public class LevelInfoGUI : MonoBehaviour
    {
        public GameObject panel;
        public TextMeshProUGUI levelName_text;
        public TextMeshProUGUI levelIndex_text;
        public TextMeshProUGUI levelStars_text;
        public Image thumbnail;
        public Button play_button;
        public Button close_button;

        public List<Button> level_buttons;

        private LevelSelector levelSelector;

        private void Start()
        {
            levelSelector = FindObjectOfType<LevelSelector>();
            for (int i = 0; i < level_buttons.Count; i++)
            {
                int idx = i;
                level_buttons[idx].onClick.AddListener(()=>levelSelector.SelectLevel(idx));
                level_buttons[idx].interactable = idx <= levelSelector.last_unlocked_level_index;
            }

            play_button.onClick.AddListener(levelSelector.PlayLevel);
            close_button.onClick.AddListener(levelSelector.UnselectLevel);
            
            panel.SetActive(false);        
        }

        private void OnEnable()
        {
            Events.OnSelectLevel.AddListener(UpdateUI);
            Events.OnDeselectLevel.AddListener(HidePanel);
        }

        private void OnDisable()
        {
            Events.OnSelectLevel.RemoveListener(UpdateUI);
            Events.OnDeselectLevel.RemoveListener(HidePanel);
        }

        private void UpdateUI(int index)
        {
            panel.SetActive(true);
            Level level = FindObjectOfType<LevelSelector>().GetSelectedLevel();
            levelName_text.text = level.levelname;
            levelIndex_text.text = "Nivel " + (index + 1);
            if (level.thumbnail != null) thumbnail.sprite = level.thumbnail;
            // if(PlayerSettings.levelScores.Count > index)
            // {
            //     string stars = "";
            //     for (int i = 0; i < PlayerSettings.levelScores[index]; i++)
            //     {
            //         stars += "*";
            //     }
            //     levelStars_text.text = stars;
            // }
            // else
            // {
            //     levelStars_text.text = "---";
            // }
        }


        private void HidePanel()
        {
            panel.SetActive(false);
        }

        public void GoToMainMenu()
        {
            //
        }
    } 
}
