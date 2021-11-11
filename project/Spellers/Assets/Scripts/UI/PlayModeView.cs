using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
            btn_singlePlayerMode.onClick.AddListener(() => SceneManager.LoadScene("Game"));
            btn_historyMode.onClick.AddListener(() => SceneManager.LoadScene("ModoHistoria"));
        }
    } 
}