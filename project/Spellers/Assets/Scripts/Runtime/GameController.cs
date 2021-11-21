using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Utils;
using Runtime.CombatSystem;
using SpellSystem;

namespace Runtime
{

    public class GameController : Singleton<GameController>
    {
        const int MAIN_SCENE = 0;
        const int HISTORY_MODE_SCENE = 1;
        const int COMBAT_SCENE = 2;

        public Spell basic_spell;
        public Sprite player_icon;

        public void Start()
        {
            PlayerSettings.icon = player_icon;
            if(PlayerSettings.deck.spells.Count < 10)
            {
                PlayerSettings.deck.spells.Clear();
                for (int i = 0; i < 10; i++)
                {
                    PlayerSettings.deck.AddSpell(basic_spell);
                }
            }
        }

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
        }

        public void GoToMainMenu()
        {
            SceneManager.LoadScene(0);
        }
    }  
}

