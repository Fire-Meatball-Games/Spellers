using System;
using System.Collections;
using System.Collections.Generic;
using Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace BattleManagement.UI
{
    public class BattlePause : MonoBehaviour
    {
        [SerializeField] private RectTransform layout;
        [SerializeField] private Button exit_button;
        [SerializeField] private Button continue_button;
        [SerializeField] private Button pause_button;

        private EffectBuilder showEffects, hideEffects;

        private void Awake() 
        {   
            showEffects = new EffectBuilder(this)
            .AddEffect(new ScreenSlideEffect(layout, Vector3.up * 1.2f, Vector3.zero,  1.1f, 0.2f))
            .AddEffect(new EnableEffect(layout.gameObject, 0f, true));
            hideEffects = new EffectBuilder(this)
            .AddEffect(new ScreenSlideEffect(layout, Vector3.zero, Vector3.up * 1.2f, 1.0f, 0.2f))
            .AddEffect(new EnableEffect(layout.gameObject, 0.2f, false));

            pause_button.onClick.AddListener(Pause);  
            continue_button.onClick.AddListener(Continue);
            exit_button.onClick.AddListener(Exit); 
        }

        private void Pause()
        {
            Show();  
            Invoke("PauseTime", 0.2f);          
        }

        private void Continue()
        {
            Time.timeScale = 1f;
            Hide();
        }

        private void Exit()
        {
            Time.timeScale = 1f;
            // Salir de la partida...
            Hide();
        }

        
        public void Show()
        {
            showEffects.ExecuteEffects();
        }

        public void Hide()
        {
            hideEffects.ExecuteEffects();
        }

        private void PauseTime() => Time.timeScale = 0f;
    }

}
