using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace UIManagement
{
    public class CustomView : View
    {
        [SerializeField] private Button btn_editarMazo;
        [SerializeField] private Button btn_editarSombrero;
        [SerializeField] private Button btn_atras;

        public override void Init()
        {
            Animator animacion = GetComponent<Animator>();

            btn_atras.onClick.AddListener(() => animacion.SetBool("Salir", true));
            btn_atras.onClick.AddListener(() => Invoke("salir", 1.0f));

            btn_editarMazo.onClick.AddListener(() => animacion.SetBool("Salir", true));
            btn_editarMazo.onClick.AddListener(() => Invoke("editarMazo", 1.0f));

            btn_editarSombrero.onClick.AddListener(() => animacion.SetBool("Salir", true));
            btn_editarSombrero.onClick.AddListener(() => Invoke("editarSombrero", 1.0f));
        }

        public void salir()
        {
            ViewManager.ShowLast();
        }

        public void editarMazo()
        {
            ViewManager.Show<DeckView>();
        }

        public void editarSombrero()
        {
            ViewManager.Show<HatView>();
        }
    }
}
