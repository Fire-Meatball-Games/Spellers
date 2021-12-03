using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Ingame.UI
{
    public class TestGame : GameBoard
    {
        [SerializeField] private Button success_button;
        [SerializeField] private Button fail_button;
        public override void Generate()
        {
            success_button.onClick.AddListener(Success);
            fail_button.onClick.AddListener(Fail);
        }
    }

}
