using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace UIManagement
{
    public class SinglePlayerView : View
    {
        [SerializeField] private Button btn_personalizar;
        [SerializeField] private Button btn_historyMode;
        [SerializeField] private Button btn_singlePlayerMode;
        [SerializeField] private Button btn_tutorial;

        [SerializeField] private Button btn_atras;

        public override void Init()
        {
            btn_personalizar.onClick.AddListener(() => ViewManager.Show<CustomView>());
            //btn_historyMode.onClick.AddListener(() => GameManager.LoadScene("ModoHistoria"));
            btn_singlePlayerMode.onClick.AddListener(() => SceneManager.LoadScene("Game"));
            btn_atras.onClick.AddListener(() => ViewManager.ShowLast());
        }
    } 
}