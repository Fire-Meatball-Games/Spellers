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
        
        public void UpdateState(int value)
        {
            icon_image.gameObject.SetActive(value != 0);
            icon_image.sprite = value > 0 ? positive_icon : negative_icon;
            textDisplay.text = value != 0? value.ToString() : "";
        }
      

    }
}

