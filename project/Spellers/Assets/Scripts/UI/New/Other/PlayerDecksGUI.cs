using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using SpellSystem;
using PlayerManagement;
using CustomEventSystem;

namespace UIManagement
{
    public class PlayerDecksGUI : MonoBehaviour
    {    
        [Header("Deck power display")]
        [SerializeField] private Slider deckPower_slider;
        [SerializeField] private TextMeshProUGUI deckPower_text;

        [Header("Deck selector")]
        [SerializeField] private List<Button> deckSelector_buttons;

        [Header("Deck display")]
        [SerializeField] private RectTransform deckDisplay;
        [SerializeField] private GameObject spellCard_prefab;

        private List<CardView> spellCards;

        void Start()
        {
            deckPower_slider.maxValue = 3f;            
            SetUpDeckDisplay();

        }

        private void DisplayDeck(SpellDeck deck)
        {
            float averagePower = deck.GetAveragePower();
            deckPower_text.text = averagePower.ToString("0.00");
            deckPower_slider.value = averagePower;
        }

        private void ClearDeckDisplay()
        {

        }

        private void SetUpDeckDisplay()
        {
            spellCards = new List<CardView>(SpellDeck.DECKSIZE);
            for (var i = 0; i < SpellDeck.DECKSIZE; i++)
            {
                var cardView_go = Instantiate(spellCard_prefab, deckDisplay);
                CardView cardView = cardView_go.GetComponent<CardView>();
                spellCards.Add(cardView);
            }
        }
    }    
}

