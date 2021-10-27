using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SpellSystem;

namespace Runtime.CombatSystem
{
    /// <summary>
    /// Genera los jugadores de una partida
    /// </summary>
    public class BattleHUB : MonoBehaviour
    {
        [SerializeField] private SpellerNPC NPC;
        [SerializeField] private SpellerPlayer player;
        

        [SerializeField] private List<Spell> NPC_Spells;
        [SerializeField] private List<Spell> player_spells;

        [SerializeField] private GameObject spellerNPC_prefab;

        public void Start()
        {
            NPC?.SetDeck(NPC_Spells);
        }
    }

}