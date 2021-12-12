using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tweening;
using Levels;
using GameManagement;
using UnityEngine.UI;

namespace UIManagement{
    public class QuickGameView : EmergentView
    {        
        [SerializeField] private RectTransform panel;
        [SerializeField] private Button play_btn;
        [SerializeField] private Button previous_btn;
        [SerializeField] private Button next_btn;
        [SerializeField] private Button random_btn;
        [SerializeField] private Image iconImage;

        private int selectedIdx;

        [SerializeField] private List<QuickGameSettings> settingList;
        public override void Init(){
            close_time = 0.2f;
            base.Init();
            show_effects.AddEffect(new ScreenSlideEffect(panel, Vector2.up, Vector2.zero, 1.2f, 0.2f));
            hide_effects.AddEffect(new ScreenSlideEffect(panel, Vector2.zero, Vector2.up, 1f, 0.2f));

            play_btn.onClick.AddListener(LoadGame);
            previous_btn.onClick.AddListener(SelectPrevious);
            next_btn.onClick.AddListener(SelectNext);
            random_btn.onClick.AddListener(SelectRandom);
        }

        private void LoadGame()
        {
            GameManager.instance.SetSettings(settingList[selectedIdx]);
            GameManager.instance.UnloadScene(SceneIndexes.MAIN_MENU);  
            GameManager.instance.LoadSceneAsync(SceneIndexes.GAME);                  

        }

        private void DisplayGameSettings()
        {
            iconImage.sprite = settingList[selectedIdx].Icon; 
        }

        private void SelectPrevious()
        {
            selectedIdx = (selectedIdx + settingList.Count - 1) % settingList.Count;
            DisplayGameSettings();
        }

        private void SelectNext()
        {
            selectedIdx = (selectedIdx + settingList.Count + 1) % settingList.Count;
            DisplayGameSettings();
        }

        private void SelectRandom()
        {
            selectedIdx = Random.Range(0, settingList.Count);
            DisplayGameSettings();
        }



    }
}


