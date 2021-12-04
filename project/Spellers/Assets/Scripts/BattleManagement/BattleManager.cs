using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ingame;
using Ingame.UI;
using PlayerManagement;
using Utils;
using System;
using CustomEventSystem;
using GameManagement;
using Levels;
using SpellSystem;

namespace BattleManagement
{
    // Es el controlador de las partidas. Se encarga de inicializar a los jugadores con los datos correspondientes, controlar el estado del juego y establecer cuando comienza, acaba o se pausa una partida.
    public class BattleManager : MonoBehaviour
    {
        #region Inspector fields
        [SerializeField] private Spawner spawner;
        [SerializeField] private HUD player_HUD;
        [SerializeField] private HUD enemy_HUD;
        [SerializeField] private SpellTableGUI game_GUI;

        [SerializeField] private BaseGameSettings default_settings;
        [SerializeField] private SpellDeck default_deck;

        #endregion

        #region Private fields
        [HideInInspector] public SpellerPlayer Player;
        [HideInInspector] public SpellerNPC Enemy;

        #endregion

        private void Start() 
        {
            SetUpPlayer();
            SetUpEnemy();  
            Player.SetTarget(Enemy);
            Enemy.SetTarget(Player); 
                    
            Events.OnBattleReady.Invoke();
            Debug.Log("Batalla lista");
        }

        // Configurar el jugador a partir de los datos de Player:
        private void SetUpPlayer()
        {            
            SetUpPlayerSettings();
            Player = spawner.GeneratePlayer();
            Player settings = PlayerManagement.Player.instance;
            Player.Icon = settings.Icon;
            Player.SpellerName = settings.PlayerName;
            Player.SetUp(settings.Deck);

            player_HUD.SetSpeller(Player);
            Debug.Log("Jugador generado" + Player.ToString());

            game_GUI.SetUp(Player);            
        }

        // Configurar el enemigo a partir de los datos de GameManager:
        private void SetUpEnemy()
        {
            SetUpGameSettings();
            Enemy = spawner.GenerateEnemy();
            BaseGameSettings settings = GameManager.instance.GetSettings(); 
            Enemy.Icon = settings.Icon;
            Enemy.SpellerName = settings.EnemyName;
            EnemyController controller = new EnemyController{
                deck = settings.Deck,
                max_spell_lvl = settings.MaxSpellLvl,
                cooldown_average = settings.Cooldown_average,
                cooldown_deviation = settings.Cooldown_deviation
            };
            Enemy.SetUp(controller);
            enemy_HUD.SetSpeller(Enemy);
            Debug.Log("Enemigo generado: " + Enemy.ToString());
        }

        // Comenzar la batalla:
        public void StartBattle()
        {
            Events.OnBattleBegins.Invoke();
            Player.Active();
            Enemy.Active();
            game_GUI.Active();
            Debug.Log("batalla comenzada");
        }

        // Pausar la partida:
        public void PauseBattle()
        {
            Time.timeScale = 0f;
        }

        // Despausar la partida:
        public void UnpauseBattle()
        {
            Time.timeScale = 1f;
        }


        private void SetUpGameSettings()
        {
            if(GameManager.instance == null)
            {
                GameManager.instance = new GameManager();
                GameManager.instance.SetSettings(default_settings);
            }
        }

        private void SetUpPlayerSettings()
        {
            if(PlayerManagement.Player.instance == null)
            {
                PlayerManagement.Player.instance = new Player();
                PlayerManagement.Player.instance.Deck = default_deck;
            }
        }


    }

}
