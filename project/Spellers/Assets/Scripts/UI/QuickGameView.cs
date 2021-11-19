using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

namespace UIManagement
{
    public class QuickGameView : View
    {
        public Button back_button;
        public override void Init()
        {
            back_button.onClick.AddListener(ViewManager.ShowLast);
        }

        
    }

}
