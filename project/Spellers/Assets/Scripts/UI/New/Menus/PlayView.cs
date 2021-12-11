using System.Collections;
using System.Collections.Generic;
using Tweening;
using UnityEngine;
using UnityEngine.UI;
using GameManagement;

namespace UIManagement
{
    public class PlayView : MenuView
    {
        [Header("Pantallas")] 
        [SerializeField] private QuickGameView quickGameView;

        [Header("Botones")]
        [SerializeField] private Button historyMode_btn;
        [SerializeField] private Button quickGame_btn;
        [SerializeField] private Button multiplayer_btn;

        public override void Init()
        {
            historyMode_btn.onClick.AddListener(LoadHistoryMode);
            quickGame_btn.onClick.AddListener(quickGameView.Show);           
        }

        private void LoadHistoryMode()
        {
            GameManager.instance.UnloadScene(SceneIndexes.MAIN_MENU);
            GameManager.instance.LoadSceneAsync(SceneIndexes.LEVEL_MAP);
        }




    }

}