using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Runtime.CombatSystem;
using System;
using CustomEventSystem;

namespace Runtime
{

    public class SpellerBattle : MonoBehaviour
    {
        public SpellerPlayer player;
        public List<SpellerNPC> enemies;

        private void Awake()
        {
            enemies = new List<SpellerNPC>();
        }

        // Añade al jugador
        public void AddPlayer(SpellerPlayer player)
        {
            this.player = player;
            player.SetSettings();
            Events.OnDefeatPlayer.AddListener(() => FinishBattle(false));
            Events.OnJoinPlayer.Invoke();
        }

        // Añade un enemigo a la partida
        public void AddEnemy(SpellerNPC spellerNPC, int idx)
        {
            enemies.Add(spellerNPC);
            Events.OnDefeatEnemy.AddListener(DefeatEnemy);
            Events.OnJoinEnemy.Invoke(idx);
        }           

        // Finaliza la batalla
        public void FinishBattle(bool victory = true)
        {
            Events.OnBattleEnds.Invoke(victory);
            foreach (var speller in enemies)
            {
                Destroy(speller.gameObject);
            }
        }

        // Comienza la batalla
        public void BeginBattle()
        {
                    
        }

        public void PauseBattle(bool pause)
        {
            Events.OnPauseBattle.Invoke(pause);
            Time.timeScale = pause ? 0.0f : 1.0f;
            
        }

        // Elimina un enemigo de la partida
        private void DefeatEnemy(int idx)
        {
            Debug.Log("Enemigo derrotado");
            SpellerNPC enemy = enemies[idx];
            enemies.RemoveAt(idx);
            if (enemies.Count == 0)
            {
                player.target = null;
                FinishBattle();
            }
            else if (player.target == enemy)
            {
                player.target = enemies[0];
            }
        }
    } 
}
