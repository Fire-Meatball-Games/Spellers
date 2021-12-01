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
    public class SpellCollectionGUI : MonoBehaviour
    {   
        [SerializeField] private GameObject cardList_prefab;
        [SerializeField] private GameObject cardView_prefab;
        [SerializeField] private RectTransform display;
        private CardSection section;

        public void Init()
        {      
            List<Spell> allSpells = Spell.GetAllSpells();
            AddCardSection("Hechizos", allSpells);              
        }

        private void AddCardSection(string title, List<Spell> spells)
        {
            section = Instantiate(cardList_prefab, display).GetComponent<CardSection>();
            section.SetLayout(title, GetCardViewList(spells));            
        }

        private List<CardView> GetCardViewList(List<Spell> spells)
        {
            List<CardView> cards = new List<CardView>();
            foreach (var spell in spells)
            {
                cards.Add(GenerateCardView(spell));                
            }
            return cards;
        }

        private SpellCardView GenerateCardView(Spell spell)
        {
            SpellCardView card = Instantiate(cardView_prefab).GetComponent<SpellCardView>(); 
            card.SetUp(spell, false);
            return card;
        }
    }
}

