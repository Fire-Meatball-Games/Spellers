using UnityEngine;
using UnityEngine.UI;
using GameManagement;

namespace UIManagement
{
    public class PlayModeView : View
    {
        [SerializeField] private Button btn_historyMode;
        [SerializeField] private Button btn_multiplayerMode;
        [SerializeField] private Button btn_singlePlayerMode;
        [SerializeField] private Button btn_tutorial;

        [SerializeField] private Button btn_atras;

        public override void Init()
        {
            //btn_historyMode.onClick.AddListener(() => GameManager.LoadScene("ModoHistoria"));
            btn_atras.onClick.AddListener(() => ViewManager.ShowLast());
        }
    } 
}