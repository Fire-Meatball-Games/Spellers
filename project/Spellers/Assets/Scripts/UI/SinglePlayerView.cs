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
            Animator animacion = GetComponent<Animator>();
            btn_personalizar.onClick.AddListener(() => animacion.SetBool("Salir", true));
            btn_personalizar.onClick.AddListener(() => Invoke("personalizar", 1.0f));
            //btn_historyMode.onClick.AddListener(() => GameManager.LoadScene("ModoHistoria"));
            btn_singlePlayerMode.onClick.AddListener(() => SceneManager.LoadScene("Game"));
            btn_atras.onClick.AddListener(() => animacion.SetBool("Salir", true));
            btn_atras.onClick.AddListener(() => Invoke("salir", 1.0f));
        }

        public void personalizar()
        {
            ViewManager.Show<CustomView>();
        }

        public void salir()
        {
            ViewManager.ShowLast();
        }
    } 
}