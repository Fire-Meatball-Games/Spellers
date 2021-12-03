using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SpellSystem;
using Tweening;
using CustomEventSystem;

namespace Ingame.UI
{
    // Controla el HUD de un personaje. Cuando una estadistica cambia se llama al metodo correspondiente para actualizar la interfaz.
    // Hasta que no se le asigna un personaje con SetSpeller( ), la interfaz permanece inactiva.
    public class HUD : MonoBehaviour
    {
        [SerializeField] private RectTransform rectTransform;
        [SerializeField] private Image icon_image;
        [SerializeField] private Slider healthSlider;
        [SerializeField] private StateDisplay attackStateDisplay;
        [SerializeField] private StateDisplay regenerationStateDisplay;
        [SerializeField] private StateDisplay cardsStateDisplay;
        [SerializeField] private StateDisplay orderStateDisplay;
        [SerializeField] private StateDisplay timeStateDisplay;

        private EffectBuilder show_effects;
        private EffectBuilder hide_effects;

        public void SetSpeller(Speller speller)
        {
            icon_image.sprite = speller.Icon;

            Stats stats = speller.Stats;
            stats.OnChangeHealthEvent += OnHealthChangedCallback;
            stats.OnChangeShieldsEvent += OnShieldChangedCallback;
            stats.OnChangeAttackEvent += OnAttackPowerChangedCallback;
            stats.OnChangeRegenerationEvent += OnRegenerationChangedCallback;
            stats.OnChangeSlotLevelsEvent += OnCardsChangedCallback;
            stats.OnChangeOrderEvent += OnOrderChangedCallback;
            stats.OnChangeDifficultyEvent += OnTimeChangedCallback;
        }

        private void Awake() 
        {
            show_effects = new EffectBuilder(this)            
            .AddEffect(new EnableEffect(rectTransform.gameObject, 0f, true));
            hide_effects = new EffectBuilder(this)            
            .AddEffect(new EnableEffect(rectTransform.gameObject, 0.2f, false));
            
            Hide();
        }

        private void OnEnable() 
        {
            Events.OnBattleBegins.AddListener(Show);
        }

        private void OnDisable() 
        {
            Events.OnBattleBegins.RemoveListener(Show);
        }

        // Metodo lanzado cuando la vida del jugador cambia:
        private void OnHealthChangedCallback(int value)
        {
            
        }

        // Metodo lanzado cuando los escudos del jugador cambian:
        private void OnShieldChangedCallback(int value)
        {
            
        }

        // Metodo lanzado cuando el poder de ataque del jugador cambia:
        private void OnAttackPowerChangedCallback(float value)
        {
            attackStateDisplay.UpdateState((int)value);
        }

        // Metodo lanzado cuando el poder de ataque del jugador cambia:
        private void OnRegenerationChangedCallback(int value)
        {
            regenerationStateDisplay.UpdateState(value);
        }

        // Metodo lanzado cuando el poder de ataque del jugador cambia:
        private void OnCardsChangedCallback(int value)
        {
            cardsStateDisplay.UpdateState(value);
        }

        // Metodo lanzado cuando el poder de ataque del jugador cambia:
        private void OnOrderChangedCallback(int value)
        {
            orderStateDisplay.UpdateState(value);
        }

        // Metodo lanzado cuando el poder de ataque del jugador cambia:
        private void OnTimeChangedCallback(int value)
        {
            timeStateDisplay.UpdateState(value);
        }

        private void Show()
        {
            show_effects.ExecuteEffects();
        }

        private void Hide()
        {
            hide_effects.ExecuteEffects();
        }

    }

}

