using UnityEngine;
using UnityEngine.UI;

namespace UIManagement
{
    public class ColectionView : View
    {
        [SerializeField] private Button btn_atras;

        public override void Init()
        {
            btn_atras.onClick.AddListener(() => ViewManager.ShowLast());
        }
    } 
}