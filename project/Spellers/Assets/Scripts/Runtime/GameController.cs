using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Utils;
using Runtime.CombatSystem;

namespace Runtime
{
    public class HistoryModeSettings
    {
        public int last_level_unlocked;
        public bool show_last_level_dialogue;

        public void CompleteHistoryModeLevel()
        {
            last_level_unlocked++;
        }
    }

    public class GameController : Singleton<GameController>
    {
        const int MAIN_SCENE = 0;
        const int HISTORY_MODE_SCENE = 1;
        const int COMBAT_SCENE = 2;        

        public GameSettings game_settings;
        public HistoryModeSettings historyMode_settings; 

        public void SetCombatSettings(GameSettings settings) => game_settings = settings;

        public void LoadScene(string scene)
        {
            SceneManager.LoadScene(scene);
        }

        public void LoadCombat()
        {
            StartCoroutine(LoadCombatCorroutine());
        }

        // Carga la pantalla de juego a partir de la configuración guardada en settings
        private IEnumerator LoadCombatCorroutine()
        {
            yield return SceneManager.LoadSceneAsync(COMBAT_SCENE);
            SpellerBattle battle = FindObjectOfType<SpellerBattle>();
        }
    }  
}

