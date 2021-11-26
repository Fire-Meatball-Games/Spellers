using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utils;
using SpellSystem;

namespace PlayerManagement 
{
    public class PlayerSettings : Singleton<PlayerSettings>
    {
        [Header("Default Settings")]        
        [SerializeField] private string spellerName_default;
        [SerializeField] private Sprite icon_default;        
        [SerializeField] private SpellDeck deck_default;
        [SerializeField] private SpellCollection all_spells;


        public static readonly int NUM_DECKS = 3;
        private string m_playerName;
        private Sprite m_icon;
        private List<SpellDeck> m_decks;
        private int m_selected_deck;
        private BitArray unlocked_spells_mask;


        public override void Init()
        {
            base.Init();
            m_decks = new List<SpellDeck>(NUM_DECKS);
        }


    }

}
