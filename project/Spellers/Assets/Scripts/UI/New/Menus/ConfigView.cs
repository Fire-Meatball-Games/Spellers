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
        [SerializeField] private Button credits_button;
        [SerializeField] private TutorialsView tutorialsView;
        [SerializeField] private CreditsView creditsView;

        [SerializeField] private Slider volumeSlider, musicSlider, sfxSlider;

        public override void Init()
        {
            tutorials_button.onClick.AddListener(tutorialsView.Show);
            credits_button.onClick.AddListener(creditsView.Show);
        }
    }
}
