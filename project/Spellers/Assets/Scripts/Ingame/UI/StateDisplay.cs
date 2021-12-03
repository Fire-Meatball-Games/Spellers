using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Ingame.UI
{
    // Define un estado del HUD del jugador, formado por una imagen que muestra el estado (positivo, negativo o ninguno) y un texto con su valor concreto.
    public class StateDisplay : MonoBehaviour
    {
        [SerializeField] private Sprite positive_icon;
        [SerializeField] private Sprite negative_icon;
        [SerializeField] private Image icon_image;

        [SerializeField] private TextMeshProUGUI textDisplay;
        
        private int currentValue;


        public void UpdateState(int value)
        {
            
        }

        private void SetTransition(int currentValue, int newValue)
        {

        }


        

    }
}

