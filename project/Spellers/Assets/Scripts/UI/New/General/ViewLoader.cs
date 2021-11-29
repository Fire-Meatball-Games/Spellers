using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UIManagement
{
    public class ViewLoader : MonoBehaviour
    {
        [SerializeField] private List<View> views;
        [SerializeField] private MenuSlider menuSlider;
        private void Awake() 
        {
            foreach (var view in views)
            {
                view.Init();
            }

            menuSlider.SetUp();
        }
    }
}

