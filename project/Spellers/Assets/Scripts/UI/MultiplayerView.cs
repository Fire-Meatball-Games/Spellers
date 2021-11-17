using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace UIManagement
{
    public class MultiplayerView : View
    {
        [SerializeField] private Button btn_personalizar;
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
