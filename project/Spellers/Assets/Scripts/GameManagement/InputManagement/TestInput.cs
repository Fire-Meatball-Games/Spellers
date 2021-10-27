using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace InputManagement
{
    public class TestInput : MonoBehaviour
    {
        public InputManager inputManager;
        public Text text;
        // Start is called before the first frame update

        private void OnEnable()
        {
            inputManager.OnStartClick += (Vector2 v) => text.text = "Start " + v;
            inputManager.OnEndClick += (Vector2 v) => text.text = "End " + v;
            inputManager.OnPerformClick += (Vector2 v) => text.text = "Perform " + v;
        }
    }  
}
