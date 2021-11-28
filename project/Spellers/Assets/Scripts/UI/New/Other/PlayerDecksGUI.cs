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
        [SerializeField] private CardSection cardSection;
        [SerializeField] private GameObject spellCard_prefab;
        [SerializeField] private SpellDetailsView spellDetailsView;

        private SpellDeck selectedDeck;

        public void Init()
        {
            deckPower_slider.maxValue = 3f;     
            cardSection.SetUp("Mazo de hechizos", SpellDeck.DECKSIZE);    

            selectedDeck = PlayerSettings.instance.SelectedDeck;

            for (int i = 0; i < SpellDeck.DECKSIZE; i++)
            {
                SpellCardView cardView = Instantiate(spellCard_prefab).GetComponent<SpellCardView>();    
                cardView.SetUp();
                cardSection.AddToLayout(cardView);
            }

            for(int i = 0; i < deckSelector_buttons.Count; i++)
            {
                int idx = i;
                deckSelector_buttons[i].onClick.AddListener(() => SelectDeck(idx));
            }
        }

        private void OnEnable() 
        {
            Events.OnAddSpellToDeck.AddListener(DisplaySelectedDeck);
        }
        private void OnDisable() 
        {
            Events.OnAddSpellToDeck.RemoveListener(DisplaySelectedDeck);
        }

        private void DisplaySelectedDeck() => DisplayDeck(PlayerSettings.instance.SelectedDeck);

        private void DisplayDeck(SpellDeck deck)
        {
            //cardSection.Clear();

            if(deck == null)
                deck = new SpellDeck();

            float averagePower =  deck.GetAveragePower();
            deckPower_text.text = averagePower.ToString("0.00");
            deckPower_slider.value = averagePower;

            for (int i = 0; i < SpellDeck.DECKSIZE; i++)
            {
                if(i < selectedDeck.Count)
                {
                    Spell spell = deck.spells[i]; 
                    cardSection.GetCardView(i).SetUp(spell, true);              
                }
                else
                {
                    cardSection.GetCardView(i).SetUp();
                }

                
            }
        }

        private void SelectDeck(int idx)
        {
            PlayerSettings.instance.SetSelectedDeckIdx(idx);
            selectedDeck = PlayerSettings.instance.SelectedDeck;
            DisplaySelectedDeck();            
        }
    }    
}

