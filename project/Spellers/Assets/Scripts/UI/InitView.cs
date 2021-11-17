using UnityEngine;
using UnityEngine.UI;

namespace UIManagement
{
    public class InitView : View
    {
        [SerializeField] private Button btn_empezar;

        public override void Init()
        {
            btn_empezar.onClick.AddListener(() => GetComponent<Animator>().SetBool("Salir", true));
            btn_empezar.onClick.AddListener(() => Invoke("iniciar", 1.0f));
        }

        public void iniciar()
        {
            ViewManager.Show<MainMenuView>();
        }
    } 
}