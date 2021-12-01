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

        [Header("Deck display")]
        [SerializeField] private GameObject cardList_prefab;
        [SerializeField] private GameObject cardView_prefab;
        [SerializeField] private RectTransform display;
        private CardSection section;

        #region Unity Callbacks
        private void OnEnable() 
        {
            Events.OnModifyPlayerDeck.AddListener(DisplaySelectedDeck);
        }
        private void OnDisable() 
        {
            Events.OnModifyPlayerDeck.RemoveListener(DisplaySelectedDeck);
        }
        #endregion

        #region Initialization
        public void Init()
        {            
            List<Spell> playerSpells = PlayerSettings.instance.Deck.ToList();
            AddCardSection("Hechizos", playerSpells);
            deckPower_slider.maxValue = 3f;
        }  
        #endregion     

        #region Private Methods

        // Añade una seccion de cartas:
        private void AddCardSection(string title, List<Spell> spells)
        {
            section = Instantiate(cardList_prefab, display).GetComponent<CardSection>();
            section.SetLayout(title, GetCardViewList(spells, SpellDeck.DECKSIZE));
        }
        
        // Genera una lista de cartas a partir de una lista de hechizos. La diferencia entre el tamaño de la lista
        // y el valor de size será el número de cartas en blanco:
        private List<CardView> GetCardViewList(List<Spell> spells, int size = 0)
        {
            List<CardView> cards = new List<CardView>();
            foreach (var spell in spells)
            {
                cards.Add(GenerateCardView(spell));                
            }
            for (var i = spells.Count; i < size; i++)
            {
                cards.Add(GenerateBlankCard());   
            }
            return cards;
        }

        // Genera una carta a partir de un hechizo:
        private SpellCardView GenerateCardView(Spell spell)
        {
            SpellCardView card = Instantiate(cardView_prefab).GetComponent<SpellCardView>(); 
            card.SetUp(spell, true);
            return card;
        }

        // Genera una carta en blanco:
        private SpellCardView GenerateBlankCard()
        {
            SpellCardView card = Instantiate(cardView_prefab).GetComponent<SpellCardView>(); 
            card.SetUp();
            return card;
        }
        #endregion

        #region Callbacks

        // Metodo llamado cuando el mazo del jugador cambia:
        private void DisplaySelectedDeck() => DisplayDeck(PlayerSettings.instance.Deck);

        // Actualiza las cartas del mazo
        private void DisplayDeck(SpellDeck deck)
        {
            float averagePower =  deck.GetAveragePower();
            deckPower_text.text = averagePower.ToString("0.00");
            deckPower_slider.value = averagePower;

            for (int i = 0; i < SpellDeck.DECKSIZE; i++)
            {
                if(i < deck.Count)
                {
                    Spell spell = deck.spells[i]; 
                    CardView cardView = GenerateCardView(spell);
                    section.SetCardAt(cardView, i);              
                }
                else
                {
                    CardView cardView = GenerateBlankCard();
                    section.SetCardAt(cardView, i);          
                }                
            }
        }
        #endregion        
    }    
}

