using System.Collections;
using System.Collections.Generic;
using Tweening;
using UnityEngine;
using UnityEngine.UI;

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
            quickGame_btn.onClick.AddListener(quickGameView.Show);           
        }





    }

}