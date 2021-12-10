using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SpellSystem;
using Tweening;
using CustomEventSystem;
using TMPro;

namespace Ingame.UI
{
    // Controla el HUD de un personaje. Cuando una estadistica cambia se llama al metodo correspondiente para actualizar la interfaz.
    // Hasta que no se le asigna un personaje con SetSpeller( ), la interfaz permanece inactiva.
    public class HUD : MonoBehaviour
    {
        [SerializeField] private RectTransform rectTransform;
        [SerializeField] private Image icon_image;
        [SerializeField] private Slider healthSlider;
        [SerializeField] private Image shieldImage;
        [SerializeField] private TextMeshProUGUI shield_txt;
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
            healthSlider.maxValue = Stats.MAX_HEALTH;

            Stats stats = speller.Stats;
            stats.OnChangeHealthEvent += OnHealthChangedCallback;
            stats.OnChangeShieldsEvent += OnShieldChangedCallback;
            stats.OnChangeAttackEvent += OnAttackPowerChangedCallback;
            stats.OnChangeRegenerationEvent += OnRegenerationChangedCallback;
            stats.OnChangeSlotLevelsEvent += OnCardsChangedCallback;
            stats.OnChangeOrderEvent += OnOrderChangedCallback;
            stats.OnChangeDifficultyEvent += OnTimeChangedCallback;

            OnHealthChangedCallback(stats.Health);
            OnShieldChangedCallback(stats.Shields);
            OnAttackPowerChangedCallback(stats.AttackState.CurrentValue);
            OnRegenerationChangedCallback(stats.RegenerationState.CurrentValue);
            OnCardsChangedCallback(stats.CardsState.CurrentValue);
            OnOrderChangedCallback(stats.OrderState.CurrentValue);
            OnTimeChangedCallback(stats.TimeState.CurrentValue);
        }

        private void Awake() 
        {
            show_effects = new EffectBuilder(this)            
            .AddEffect(new EnableEffect(rectTransform.gameObject, 0f, true))
            .AddEffect(new ScreenSlideEffect(rectTransform, Vector2.up * 0.5f, Vector2.zero, 1.2f, 0.2f));
            hide_effects = new EffectBuilder(this)            
            .AddEffect(new EnableEffect(rectTransform.gameObject, 0.2f, false))
            .AddEffect(new ScreenSlideEffect(rectTransform, Vector3.zero, Vector2.up * 0.5f, 1f, 0.2f));
            
            HideInstant();
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
            healthSlider.value = value;
        }

        // Metodo lanzado cuando los escudos del jugador cambian:
        private void OnShieldChangedCallback(int value)
        {
            shieldImage.gameObject.SetActive(value != 0);
            shield_txt.text = value.ToString();
        }

        // Metodo lanzado cuando el poder de ataque del jugador cambia:
        private void OnAttackPowerChangedCallback(int value)
        {
            Debug.Log("Ataque: " + value);
            attackStateDisplay.UpdateState(value);
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

        private void HideInstant() => rectTransform.gameObject.SetActive(false);

    }

}

