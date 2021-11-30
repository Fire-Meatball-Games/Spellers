using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using PlayerManagement;

namespace UIManagemet
{
    public class Header : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI playerName_txt;

        [SerializeField] private TextMeshProUGUI playerCurrency_txt;
        [SerializeField] private Image playerIcon_img;

        private void Awake() 
        {
            if(PlayerSettings.instance != null)
            {
                string name = PlayerSettings.instance.PlayerName;
                if(!string.IsNullOrEmpty(name))
                    playerName_txt.text = name;

                Sprite icon = PlayerSettings.instance.Icon;
                if(icon != null)
                    playerIcon_img.sprite = icon;
                int currency = PlayerSettings.instance.Coins;
                playerCurrency_txt.text = currency.ToString();              
            }
        }

        public void UpdateIcon(Sprite sprite)
        {
            if(sprite != null)
                playerIcon_img.sprite = sprite;
        }

    }
}
