using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ingame;
using Ingame.UI;
using PlayerManagement;
using Utils;
using System;

namespace BattleManagement
{
    // Es el controlador de las partidas. Se encarga de inicializar a los jugadores con los datos correspondientes, controlar el estado del juego y establecer cuando comienza, acaba o se pausa una partida.
    public class BattleManager : MonoBehaviour
    {
        #region Inspector fields
        [SerializeField] private Spawner spawner;
        [SerializeField] private HUD player_HUD;
        [SerializeField] private HUD enemy_HUD;

        #endregion

        #region Private fields
        private SpellerPlayer player;
        private SpellerNPC enemy;

        #endregion

        private void Awake() 
        {
            SetUpPlayer();
            SetUpEnemy();

            // Cargar Pantalla de inicio de combate.
        }

        // Configurar el jugador a partir de los datos de Player:
        private void SetUpPlayer()
        {
            player = spawner.GeneratePlayer();
            Player settings = Player.instance;
            player.Icon = settings.Icon;
            player.SpellerName = settings.PlayerName;
            player.SetDeck(settings.Deck);
            player.SetUp();
            player_HUD.SetSpeller(player);
        }

        // Configurar el enemigo a partir de los datos de Enemy

        private void SetUpEnemy()
        {
            enemy = spawner.GenerateEnemy();
            //EnemySettings settings; 
            enemy_HUD.SetSpeller(enemy);
        }

        private void StartBattle()
        {

        }

        private void PauseBattle()
        {

        }


    }

}
