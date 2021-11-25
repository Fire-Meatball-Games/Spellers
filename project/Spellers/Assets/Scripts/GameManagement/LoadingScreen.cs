using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Tweening;
using TMPro;

namespace GameManagement{
    public class LoadingScreen : MonoBehaviour
    {
        [SerializeField] private GameObject loadScreenPanel;
        [SerializeField] private Slider progressBar;
        [SerializeField] private TextMeshProUGUI textDisplay;

        public void SetProgressBarValue(float value)
        {
           progressBar.value = value;
        }
        public void SetDisplayMessage(string message)
        {
            textDisplay.text = message;
        }

        public void Show()
        {
            loadScreenPanel.SetActive(true);
        }

        public void Hide()
        {
            loadScreenPanel.SetActive(false);
        }
    }
}
