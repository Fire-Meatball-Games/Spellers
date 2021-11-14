using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace UIManagement
{
    public class MultiplayerView : View
    {
        [SerializeField] private Button btn_personalizar;
        [SerializeField] private Button btn_atras;

        public override void Init()
        {
            btn_personalizar.onClick.AddListener(() => ViewManager.Show<CustomView>());
            btn_atras.onClick.AddListener(() => ViewManager.ShowLast());
        }
    }
}
