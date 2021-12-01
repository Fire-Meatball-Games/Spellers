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
        private Skin m_skin;
        private int coins;
        private SpellDeck m_deck;

        #endregion

        public override void Init()
        {
            base.Init();      
            m_deck = new SpellDeck();
            m_skin = new Skin();
        }

        public string PlayerName { get => m_playerName; set => m_playerName = value; }
        public string Id { get => m_ID; set => m_ID = value; }
        public Sprite Icon { get => m_icon; set => m_icon = value; }
        public int Coins { get => coins; set => coins = value; }
        public Skin Skin { get => m_skin; }
        public SpellDeck Deck { get => m_deck;}
    }

}
