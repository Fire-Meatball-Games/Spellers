using UnityEngine;
using UnityEngine.UI;

namespace UIManagement
{
    public class SettingsView : View
    {
        [SerializeField] private Button btn_atras;

        public override void Init()
        {
            Animator animacion = GetComponent<Animator>();
            btn_atras.onClick.AddListener(() => animacion.SetBool("Salir", true));
            btn_atras.onClick.AddListener(() => Invoke("salir", 1.0f));
        }

        public void salir()
        {
            ViewManager.ShowLast();
        }
    } 
}