using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utils;
using SpellSystem;

namespace PlayerManagement 
{
    public class PlayerSettings : Singleton<PlayerSettings>
    {
        #region Public fields

        [Header("Default Settings")]        
        [SerializeField] private string spellerName_default;
        [SerializeField] private Sprite icon_default;   

        #endregion     

        #region Private fields
        public static readonly int NUM_DECKS = 3;
        private string m_playerName;
        private Sprite m_icon;
        private SpellDeck[] m_decks;
        private int m_selectedDeck;
        private BitArray unlocked_spells_mask;

        #endregion

        public override void Init()
        {
            base.Init();
            m_icon = icon_default;
            
            m_decks = new SpellDeck[NUM_DECKS];

            for (int i = 0; i < NUM_DECKS; i++)
            {
                m_decks[i] = new SpellDeck();
            }
            
        }

        public SpellDeck GetDeck(int idx)
        {
            if(idx > 0 && idx < NUM_DECKS)
            {
                return m_decks[idx];
            }
            else 
                return null;
        }

        public SpellDeck SelectedDeck => m_decks[m_selectedDeck];

        public void SetSelectedDeckIdx(int idx)
        {
            if(idx >= 0 && idx < NUM_DECKS)
                m_selectedDeck = idx;
            else
                return;            
        }

    }

}
