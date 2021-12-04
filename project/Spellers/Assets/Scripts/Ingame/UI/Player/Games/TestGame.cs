using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Ingame.UI
{
    public class TestGame : GameBoard
    {
        [SerializeField] private GameObject test_button;
        public override void Generate()
        {
            var sc_obj = Instantiate(test_button, rectTransform);
            var sc_rt = sc_obj.GetComponent<RectTransform>();
            sc_rt.anchorMin = new Vector2(0, 0.5f);
            sc_rt.anchorMax = new Vector2(1, 1);
            var sc_btn = sc_obj.GetComponent<Button>();
            sc_btn.onClick.AddListener(Success);

            var fl_obj = Instantiate(test_button, rectTransform);
            var fl_rt = fl_obj.GetComponent<RectTransform>();
            fl_rt.anchorMin = new Vector2(0, 0);
            fl_rt.anchorMax = new Vector2(1, 0.5f);
            var fl_btn = fl_obj.GetComponent<Button>();
            fl_btn.onClick.AddListener(Fail);
            
        }
    }

}
