using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Runtime
{
    public class LevelInfoGUI : MonoBehaviour
    {
        public TextMeshProUGUI levelName_text;
        public TextMeshProUGUI levelIndex_text;
        public LevelSelector selector;

        // Start is called before the first frame update
        void Awake()
        {
            selector.OnSelectLevelEvent += UpdateUI;
        }

        // Update is called once per frame
        private void UpdateUI(Level level, int index)
        {
            levelName_text.text = level.levelname;
            levelIndex_text.text = "Nivel " + index;
        }
    } 
}
