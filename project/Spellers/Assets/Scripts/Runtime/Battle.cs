using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Runtime.CombatSystem;
using System;

namespace Runtime
{
    /// <summary>
    /// Controla el estado de la partida.
    /// </summary>

    public class Battle : MonoBehaviour
    {
        public enum Status
        {
            running,
            won,
            lost
        }

        public Status status;

        public SpellerPlayer player;
        public List<SpellerNPC> enemies;
        public GameObject NPC_Prefab;

        public delegate void OnChangeBattleDelegate();
        public event OnChangeBattleDelegate OnBattleSetUpEvent;
        public event OnChangeBattleDelegate OnBeginBattle;
        public event OnChangeBattleDelegate OnEndBattle;
        public delegate void OnAddSpellerDelegate(Speller speller);
        public event OnAddSpellerDelegate OnAddSpellerNPCEvent;
        public event OnAddSpellerDelegate OnSetSpellerPlayerEvent;

        private void Awake()
        {
            enemies = new List<SpellerNPC>();
        }

        public void AddEnemy(SpellerNPC spellerNPC)
        {
            enemies.Add(spellerNPC);
            spellerNPC.Stats.OnDefeatEvent += ()=> DefeatEnemy(spellerNPC);
            OnAddSpellerNPCEvent?.Invoke(spellerNPC);
        }

        private void DefeatEnemy(SpellerNPC enemy)
        {
            Debug.Log("Enemigo derrotado");
            enemies.Remove(enemy);
            if(enemies.Count == 0)
            {
                player.target = null;
                Win();
            }
            else if (player.target == enemy)
            {
                player.target = enemies[0];
            }               
            
        }

        public void SetPlayer(SpellerPlayer player)
        {
            this.player = player;
            OnSetSpellerPlayerEvent?.Invoke(player);
        }

        public void SetUpBattle()
        {
            OnBattleSetUpEvent?.Invoke();
        }

        public void Begin()
        {
            OnBeginBattle?.Invoke();
            foreach (var speller in enemies)
            {   
                 speller.Active();
            }
        }

        public void Win()
        {
            status = Status.won;
            OnEndBattle?.Invoke();
            foreach (var speller in enemies)
            {
                Destroy(speller.gameObject);
            }
            Destroy(player.gameObject);
        }

        public void Lose()
        {
            status = Status.lost;
            OnEndBattle?.Invoke();
            StopAllCoroutines();
            foreach (var speller in enemies)
            {
                Destroy(speller.gameObject);
            }
            Destroy(player.gameObject);
        }
    } 
}
