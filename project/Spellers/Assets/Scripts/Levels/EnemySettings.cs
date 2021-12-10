using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Skins;
using SpellSystem;

namespace Levels
{    
    public abstract class EnemySettings : ScriptableObject 
    {
        [SerializeField] private string enemyName;
        [SerializeField] private Sprite icon;       
        [SerializeField] private Skin skin;
        [SerializeField] private SpellDeck deck;
        [Range(1,3)] [SerializeField] private int maxSpellLvl = 3;
        [SerializeField] private float cooldown_average;
        [SerializeField] private float cooldown_deviation;

        public Sprite Icon { get => icon; }
        public Skin Skin { get => skin; }
        public SpellDeck Deck { get => deck; }
        public int MaxSpellLvl { get => maxSpellLvl; }
        public float Cooldown_average { get => cooldown_average; }
        public float Cooldown_deviation { get => cooldown_deviation;  }
        public string EnemyName { get => enemyName; }
    }
   
}
