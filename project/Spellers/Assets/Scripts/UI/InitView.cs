using UnityEngine;
using UnityEngine.UI;

namespace UIManagement
{
    public class InitView : View
    {
        [SerializeField] private Button btn_empezar;

        public override void Init()
        {
            btn_empezar.onClick.AddListener(() => ViewManager.Show<MainMenuView>());
        }
    } 
}