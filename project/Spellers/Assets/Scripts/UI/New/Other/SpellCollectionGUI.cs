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
        [SerializeField] private SpellCollection allSpells;
        [SerializeField] private RectTransform display;

        [SerializeField] private SpellDetailsView spellDetailsView;

        private List<CardSection> sections;

        public void Init()
        {            
            sections = new List<CardSection>();
            CardSection all_section = AddCardSection("Hechizos", allSpells.NumSpells);
            for (int i = 0; i < allSpells.NumSpells; i++)
            {     
                Spell spell = allSpells[i];
                SpellCardView card = Instantiate(cardView_prefab).GetComponent<SpellCardView>(); 
                card.SetUp(spell, false);
                all_section.AddToLayout(card);
            }
        }

        private CardSection AddCardSection(string title, int max_items)
        {
            CardSection section = Instantiate(cardList_prefab, display).GetComponent<CardSection>();
            section.SetUp(title, max_items);
            sections.Add(section);
            return section;
        }    
    }
}

