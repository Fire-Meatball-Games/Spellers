using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Tweening;

namespace UIManagement
{
    
    public class ConfigView : MenuView
    {
        [SerializeField] private Button tutorials_button;
        [SerializeField] private TutorialsView tutorialsView;


        public override void Init()
        {
            tutorials_button.onClick.AddListener(tutorialsView.Show);
        }
    }
}
