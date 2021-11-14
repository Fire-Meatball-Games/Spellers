using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace UIManagement
{
    public class CustomView : View
    {

        [SerializeField] private Button btn_atras;

        public override void Init()
        {
            btn_atras.onClick.AddListener(() => ViewManager.ShowLast());
        }
    }
}
