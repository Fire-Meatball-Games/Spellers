using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using CustomEventSystem;
using System;
using Tweening;
using DialogueSystem;
using Levels;
using PlayerManagement;

namespace LevelManagement
{
    public class LevelInfoGUI : MonoBehaviour
    {
        [SerializeField] private RectTransform layout;
        [SerializeField] private TextMeshProUGUI levelName_text;
        [SerializeField] private TextMeshProUGUI levelIndex_text;
        [SerializeField] private TextMeshProUGUI levelStars_text;
        [SerializeField] private Image thumbnail;
        [SerializeField] private Button play_button;
        [SerializeField] private Button close_button;
        [SerializeField] public List<Button> level_buttons;
        [SerializeField] private LevelSelector levelSelector;
        [SerializeField] private DialogueManager dialogueManager;

        [SerializeField] private Button back_button;

        private EffectBuilder showEffects, hideEffects;

        private void Awake()
        {
            showEffects = new EffectBuilder(this)
            .AddEffect(new ScreenSlideEffect(layout, Vector2.right * 0.5f, Vector2.zero, 1.1f, 0.2f))
            .AddEffect(new EnableEffect(layout.gameObject, 0, true));

            hideEffects = new EffectBuilder(this)
            .AddEffect(new ScreenSlideEffect(layout, Vector2.zero, Vector2.right * 0.4f, 1f, 0.2f))
            .AddEffect(new EnableEffect(layout.gameObject, 0.2f, false));

            for (int i = 0; i < level_buttons.Count; i++)
            {
                int idx = i;
                level_buttons[idx].onClick.AddListener(() => OnClickLevelButton(idx));
                level_buttons[idx].interactable = idx <= levelSelector.LastUnlockedLevelIndex;
            }

            play_button.onClick.AddListener(levelSelector.PlayLevel);
            close_button.onClick.AddListener(HidelevelDetails);

            back_button.onClick.AddListener(GoToMainMenu);
            
            layout.gameObject.SetActive(false);        
        }

        private void OnClickLevelButton(int index)
        {           
            if(index < levelSelector.LevelCount)
            {
                if(index <= levelSelector.LastUnlockedLevelIndex)
                {  
                    levelSelector.SelectLevel(index);
                    
                    if(levelSelector.LoadLevelDialogue)
                    {
                        dialogueManager.StartDialogue(levelSelector.SelectedLevel.map_dialogue, ()=> ShowLevelDetails(index));
                    }
                    else
                    {
                        ShowLevelDetails(index);
                    }
                }
            }
        }

        private void ShowLevelDetails(int index)
        {
            Level level = levelSelector.SelectedLevel;  
            levelName_text.text = level.levelname;
            levelIndex_text.text = (index + 1).ToString();
            if (level.thumbnail != null) thumbnail.sprite = level.thumbnail;
            if(Player.instance.LastLevelUnlocked >= index)
            {
                levelStars_text.text = "***";
            }
            else
            {
                 levelStars_text.text = "---";
            }
            showEffects.ExecuteEffects();
        }

        private void HidelevelDetails()
        {
            levelSelector.UnselectLevel();
            hideEffects.ExecuteEffects();
        }

        public void GoToMainMenu()
        {
            levelSelector.ReturnToMainMenu();
        }
    } 
}
