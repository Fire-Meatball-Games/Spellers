using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using CustomEventSystem;
using Tweening;
using TMPro;
using System;

namespace BattleManagement.UI
{
    public class BattleSign : MonoBehaviour
    {
        [SerializeField] private RectTransform rectTransform;
        [SerializeField] private Image player_icon;
        [SerializeField] private Image enemy_icon;
        [SerializeField] private Button start_button;    

        public event Action OnPressStart = delegate{}; 

        private EffectBuilder effects;

        private void Awake() 
        {   
            start_button.onClick.AddListener(StartButtonCallback);
            effects = new EffectBuilder(this)
            .AddEffect(new ScreenSlideEffect(rectTransform, Vector3.zero, Vector3.up, 1.0f, 0.2f))
            .AddEffect(new EnableEffect(rectTransform.gameObject, 0.2f, false));
        }

        public void SetUp(Sprite playerSprite, Sprite enemySprite)
        {
            rectTransform.gameObject.SetActive(true);
            player_icon.sprite = playerSprite;
            enemy_icon.sprite = enemySprite;
        }

        private void StartButtonCallback()
        {
            effects.ExecuteEffects();
            OnPressStart?.Invoke();
        }
        
    }
} 
