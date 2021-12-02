using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SpellSystem;
using Ingame;

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

        }

        // Metodo lanzado cuando el poder de ataque del jugador cambia:
        private void OnRegenerationChangedCallback(int value)
        {

        }

        // Metodo lanzado cuando el poder de ataque del jugador cambia:
        private void OnCardsChangedCallback(int value)
        {

        }

        // Metodo lanzado cuando el poder de ataque del jugador cambia:
        private void OnOrderChangedCallback(int value)
        {

        }

        // Metodo lanzado cuando el poder de ataque del jugador cambia:
        private void OnTimeChangedCallback(int value)
        {

        }

    }
}

