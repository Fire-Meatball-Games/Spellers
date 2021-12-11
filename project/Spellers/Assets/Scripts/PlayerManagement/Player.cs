using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utils;
using SpellSystem;
using Skins;

namespace PlayerManagement 
{
    public class Player : Singleton<Player>
    {
        public static readonly int NUM_DECKS = 5; 

        #region Private fields
        [SerializeField] private string m_ID;
        [SerializeField] private string m_playerName;
        [SerializeField] private Sprite m_icon;
        [SerializeField] private Skin m_skin;
        [SerializeField] private int coins;
        [SerializeField] private int points;
        [SerializeField] private int lastLevelUnlocked;
        [SerializeField] private SpellDeck m_deck;

        #endregion

        public override void Init()
        {
            base.Init();      
            m_deck = new SpellDeck();
        }

        public string PlayerName { get => m_playerName; set => m_playerName = value; }
        public string Id { get => m_ID; set => m_ID = value; }
        public Sprite Icon { get => m_icon; set => m_icon = value; }
        public int Coins { get => coins; set => coins = value; }
        public Skin Skin { get => m_skin; set => m_skin = value; }
        public SpellDeck Deck { get => m_deck; set => m_deck = value; }
        public int Points { get => points; set => points = value; }
        public int LastLevelUnlocked { get => lastLevelUnlocked; set => lastLevelUnlocked = value; }
    }

}
