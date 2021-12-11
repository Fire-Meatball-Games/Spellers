using Runtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueSystem;
using CustomEventSystem;
using PlayerManagement;
using Utils;
using GameManagement;
using Levels;
using System;

namespace LevelManagement
{
    public class LevelSelector : MonoBehaviour
    {
        #region Inspector fields

        [SerializeField] private List<Level> levels;
        [SerializeField] private DialogueManager dialogueManager;
        public int selectedLevelIdx = -1;
        public bool LoadLevelDialogue = true;
        public int LastUnlockedLevelIndex;
        public Level SelectedLevel => levels[selectedLevelIdx];
        
        public event Action<int> OnSelectLevel = delegate{};

        #endregion

        #region Public Methods

        private void Awake()
        {
            LastUnlockedLevelIndex = Player.instance.LastLevelUnlocked;
        }
        public void SelectLevel(int index)
        {
            selectedLevelIdx = index;
            OnSelectLevel?.Invoke(index);
        }

        public int LevelCount => levels.Count;
       

        public void UnselectLevel()
        {
            selectedLevelIdx = -1;
        }
        // Carga el nivel seleccionado:
        public void PlayLevel()
        {
            if(selectedLevelIdx != -1)
            {
                GameManager.instance.SetSettings(levels[selectedLevelIdx].settings);
                GameManager.instance.UnloadScene(SceneIndexes.LEVEL_MAP);
                GameManager.instance.LoadSceneAsync(SceneIndexes.GAME);
                
            }            
        }

        public void ReturnToMainMenu()
        {
            GameManager.instance.UnloadScene(SceneIndexes.LEVEL_MAP);
            GameManager.instance.LoadSceneAsync(SceneIndexes.MAIN_MENU);            
        }

        #endregion

    } 
}
