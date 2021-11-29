using UnityEngine;
using UnityEngine.UI;

namespace UIManagement
{
    public class SettingsView : View
    {
        [SerializeField] private Button btn_atras;
        [SerializeField] private Button btn_creditos;

        public override void Init()
        {
            Animator animacion = GetComponent<Animator>();
            btn_atras.onClick.AddListener(() => animacion.SetBool("Salir", true));
            btn_atras.onClick.AddListener(() => Invoke("salir", 1.0f));
            btn_creditos.onClick.AddListener(() => animacion.SetBool("Salir", true));
            btn_creditos.onClick.AddListener(() => Invoke("creditos", 1f));
        }

        public void salir()
        {
            ViewManager.ShowLast();
        }

        public void creditos()
        {
            ViewManager.Show<CreditsView>();
        }
    } 
}