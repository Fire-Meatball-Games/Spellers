using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tweening;

namespace UIManagement{
    public class QuickGameView : EmergentView
    {        
        [SerializeField] private RectTransform panel;
        public override void Init(){
            close_time = 0.2f;
            base.Init();
            show_effects.AddEffect(new ScreenSlideEffect(panel, Vector2.up, Vector2.zero, 1.2f, 0.2f));
            hide_effects.AddEffect(new ScreenSlideEffect(panel, Vector2.zero, Vector2.up, 1f, 0.2f));
        }



    }
}


