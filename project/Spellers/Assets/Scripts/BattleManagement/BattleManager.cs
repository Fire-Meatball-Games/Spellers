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
using DialogueSystem;

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
        [SerializeField] private DialogueManager dialogueManager;
        [SerializeField] private BattleEventStats eventStats;

        [SerializeField] private BaseGameSettings default_settings;
        [SerializeField] private SpellDeck default_deck;

        public event Action<bool> OnBattleEnds = delegate{};

        #endregion

        #region Fields
        [HideInInspector] public SpellerPlayer player;
        [HideInInspector] public SpellerNPC enemy;
        private BaseGameSettings gameSettings;

        #endregion

        private void Start() 
        {
            SetUpBattleSettings();
            SetUpGameSettings();
            SetUpPlayer();
            SetUpEnemy();  
            player.SetTarget(enemy);
            enemy.SetTarget(player); 
                    
            Events.OnBattleReady.Invoke();
            Debug.Log("Batalla lista");
        }

        // Configura la partida
        private void SetUpBattleSettings()
        {
            gameSettings = GameManager.instance.GetSettings(); 
            if(gameSettings is LevelGameSettings levelGameSettings)
            {
                if(levelGameSettings.LevelIndex == 1 || levelGameSettings.LevelIndex == 3 || levelGameSettings.LevelIndex == 8)
                {
                    eventStats.SetSpecialEvents();
                }
            }
        }

        private void OnEnable() 
        {
            Events.OnWinConditionChecked.AddListener(Win);
        }

        private void OnDisable() 
        {
            Events.OnWinConditionChecked.RemoveListener(Win);
        }

        // Configurar el jugador a partir de los datos de Player:
        private void SetUpPlayer()
        {            
            SetUpPlayerSettings();

            // Generar jugador:
            player = spawner.GeneratePlayer();

            // Configurar icono y nombre:
            Player settings = PlayerManagement.Player.instance;
            player.Icon = settings.Icon;
            player.SpellerName = settings.PlayerName;

            // Configurar mazo del jugador:
            if(gameSettings is LevelGameSettings levelGameSettings)
            {
                player.SetUp(levelGameSettings.PlayerDeck);
            }
            else if(gameSettings is QuickGameSettings quickGameSettings)
            {
                player.SetUp(settings.Deck);   
                player.skinDrawer.UpdateSkin(settings.Skin);
            }

            // Configurar eventos:    
            player.Stats.OnDefeatEvent += Lose;
            player_HUD.SetSpeller(player);

            // Configurar interfaz de juego:
            game_GUI.SetUp(player);            
        }

        // Configurar el enemigo a partir de los datos de GameManager:
        private void SetUpEnemy()
        {
            // Generar enemigo:
            enemy = spawner.GenerateEnemy();

            // Configurar icono y nombre:
            gameSettings = GameManager.instance.GetSettings(); 
            enemy.Icon = gameSettings.Icon;
            enemy.SpellerName = gameSettings.EnemyName;

            // Configurar mazo y estadisticas del enemigo:
            EnemyController controller = new EnemyController{
                deck = gameSettings.Deck,
                max_spell_lvl = gameSettings.MaxSpellLvl,
                cooldown_average = gameSettings.Cooldown_average,
                cooldown_deviation = gameSettings.Cooldown_deviation
            };
            enemy.SetUp(controller);
            enemy.skinDrawer.UpdateSkin(gameSettings.Skin);

            // Configurar eventos
            enemy.Stats.OnDefeatEvent += Win;
            enemy_HUD.SetSpeller(enemy);
        }

        // Comenzar la batalla:
        public void StartBattle()
        {
            if(gameSettings is LevelGameSettings levelGameSettings && levelGameSettings.InitDialogue != null)
            {
                dialogueManager.StartDialogue(levelGameSettings.InitDialogue, EnableBattle);
            }
            else
            {
                EnableBattle();
            }
        }

        private void EnableBattle()
        {
            Events.OnBattleBegins.Invoke();
            player.Active();
            enemy.Active();
            game_GUI.Active();
            Debug.Log("batalla comenzada");
            eventStats.StartTimer();
        }

        // Genera una configuracion de partida por defecto si no existe:
        private void SetUpGameSettings()
        {
            if(GameManager.instance == null)
            {
                GameManager.instance = new GameManager();
                GameManager.instance.SetSettings(default_settings);
            }
        }

        // Genera una configuracion del jugador por defecto si no existe:

        private void SetUpPlayerSettings()
        {
            if(PlayerManagement.Player.instance == null)
            {
                PlayerManagement.Player.instance = new Player();
                PlayerManagement.Player.instance.Deck = default_deck;
            }
        }

        // Victoria:
        private void Win()
        {
            EndBattle(true);
        }

        // Derrota:
        private void Lose()
        {            
            EndBattle(false);
        }

        // 
        private void EndBattle(bool win)
        {
            enemy.Disable();
            if(gameSettings is LevelGameSettings levelGameSettings && levelGameSettings.EndDialogue != null && win)
            {
                dialogueManager.StartDialogue(levelGameSettings.EndDialogue, () => DisableBattle(win));
                Debug.Log(levelGameSettings.LevelIndex + "/" +  Player.instance.LastLevelUnlocked);
                if(levelGameSettings.LevelIndex == Player.instance.LastLevelUnlocked + 1)
                {
                    Player.instance.LastLevelUnlocked++;
                }
            }
            else
            {
                DisableBattle(win);
            }
            
        }

        private void DisableBattle(bool win)
        {
            OnBattleEnds?.Invoke(win);
            Destroy(player.gameObject);
            Destroy(enemy.gameObject);
        }

        public void ExitBattle()
        {
            GameManager.instance.UnloadScene(SceneIndexes.GAME);
            if(gameSettings is LevelGameSettings)
            {
                GameManager.instance.LoadSceneAsync(SceneIndexes.LEVEL_MAP);
            }
            else
            {
                GameManager.instance.LoadSceneAsync(SceneIndexes.MAIN_MENU);
            }
        }
    }

}
