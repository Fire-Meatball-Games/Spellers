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

        private void Awake() => Init();

        private void Init()
        {            
            sections = new List<CardSection>();
            CardSection all_section = AddCardSection("Hechizos", allSpells.NumSpells);
            for (int i = 0; i < allSpells.NumSpells; i++)
            {     
                Spell spell = allSpells[i];
                CardView card = Instantiate(cardView_prefab).GetComponent<CardView>(); 
                card.SetUp(spell.thumbnail,() => LoadSpellDetails(spell));
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

        private void LoadSpellDetails(Spell spell)
        {
            spellDetailsView.SetUp(spell);
            spellDetailsView.Show();
        }
    }
}

