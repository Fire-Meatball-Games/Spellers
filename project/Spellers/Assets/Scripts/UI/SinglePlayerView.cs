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

        public int inic = 1;

        public void Update()
        {
            GetComponent<Animator>().SetInteger("Inicializar", inic);
        }

        public override void Init()
        {
            Animator animacion = GetComponent<Animator>();
            btn_personalizar.onClick.AddListener(() => inic = 0);
            btn_personalizar.onClick.AddListener(() => animacion.SetBool("Salir", true));
            btn_personalizar.onClick.AddListener(() => Invoke("personalizar", 1.0f));
            btn_atras.onClick.AddListener(() => inic = 1);
            btn_atras.onClick.AddListener(() => animacion.SetBool("Salir", true));
            btn_atras.onClick.AddListener(() => Invoke("salir", 1.0f));
            //btn_historyMode.onClick.AddListener(() => GameManager.LoadScene("ModoHistoria"));
            btn_historyMode.onClick.AddListener(() => inic = 0);
            btn_historyMode.onClick.AddListener(() => animacion.SetBool("Salir", true));
            btn_historyMode.onClick.AddListener(() => Invoke("modoHistoria", 1.0f));
            btn_singlePlayerMode.onClick.AddListener(() => inic = 0);
            btn_singlePlayerMode.onClick.AddListener(() => animacion.SetBool("Salir", true));
            btn_singlePlayerMode.onClick.AddListener(() => Invoke("combateLibre", 1.0f));
        }

        public void personalizar()
        {
            ViewManager.Show<CustomView>();
        }

        public void salir()
        {
            ViewManager.ShowLast();
        }

        public void modoHistoria()
        {
            SceneManager.LoadScene(1);
        }

        public void combateLibre()
        {
            ViewManager.Show<QuickGameView>();
        }
    } 
}