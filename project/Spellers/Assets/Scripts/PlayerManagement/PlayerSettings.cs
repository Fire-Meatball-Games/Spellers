using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utils;
using SpellSystem;
using Skins;

namespace PlayerManagement 
{
    public class PlayerSettings : Singleton<PlayerSettings>
    {
        public static readonly int NUM_DECKS = 5; 

        #region Private fields

        private string m_ID;
        private string m_playerName;
        private Sprite m_icon;
        private Skin skin;
        private int coins;
        private SpellDeck[] m_decks;
        private int m_selectedDeckId;

        #endregion

        public override void Init()
        {
            base.Init();      
            InitDecks();     
        }

        private void InitDecks()
        {
             m_decks = new SpellDeck[NUM_DECKS];

            for (int i = 0; i < NUM_DECKS; i++)
                m_decks[i] = new SpellDeck();      
        }

        public SpellDeck GetDeck(int idx)
        {
            if(idx > 0 && idx < NUM_DECKS)
                return m_decks[idx];
            else 
                return null;
        }

        public SpellDeck SelectedDeck => m_decks[m_selectedDeckId];
        public string PlayerName { get => m_playerName; set => m_playerName = value; }
        public string Id { get => m_ID; set => m_ID = value; }
        public Sprite Icon { get => m_icon; set => m_icon = value; }
        public int SelectedDeckId { get => m_selectedDeckId; }
        public int Coins { get => coins; set => coins = value; }
        public Skin Skin { get => skin; }

        public void SetSelectedDeckIdx(int idx)
        {
            if(idx >= 0 && idx < NUM_DECKS)
                m_selectedDeckId = idx;
            else
                return;            
        }
    }

}
