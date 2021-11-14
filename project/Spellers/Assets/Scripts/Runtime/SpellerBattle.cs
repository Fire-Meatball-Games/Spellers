using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Runtime.CombatSystem;
using System;
using CustomEventSystem;
using Runtime.DialogueSystem;

namespace Runtime
{

    public class SpellerBattle : MonoBehaviour
    {
        #region Public variables
        public SpellerPlayer player;
        public List<SpellerNPC> enemies;
        private DialogueManager dialogueManager;
        #endregion

        #region Initialization
        private void Awake()
        {
            enemies = new List<SpellerNPC>();
        }

        private void OnEnable()
        {
            Events.OnDefeatPlayer.AddListener(FinishBattleWithVictory);
            Events.OnDefeatEnemy.AddListener(DefeatEnemy);
            Events.OnEndCountDown.AddListener(BeginBattle);
        }

        private void OnDisable()
        {
            Events.OnDefeatPlayer.RemoveListener(FinishBattleWithVictory);
            Events.OnDefeatEnemy.RemoveListener(DefeatEnemy);
            Events.OnEndCountDown.RemoveListener(BeginBattle);
        }

        #endregion

        #region Private Methods

        // Añade al jugador
        public void AddPlayer(SpellerPlayer player)
        {
            this.player = player;
            player.SetSettings();
            Events.OnJoinPlayer.Invoke();
        }

        // Añade un enemigo a la partida
        public void AddEnemy(SpellerNPC spellerNPC, int idx)
        {
            enemies.Add(spellerNPC);
            Events.OnJoinEnemy.Invoke(idx);
        }

        // Comienza la batalla
        private void BeginBattle()
        {
            if (GameController.instance == null) { Events.OnBattleBegins.Invoke(); return; }

            Dialogue dialogue = GameSettings.combatSettings.init_dialogue;
            if (dialogue != null)
            {
                dialogueManager = FindObjectOfType<DialogueManager>();
                FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
                dialogueManager.EndDialogueEvent += () => SetDialogueEventHandler(Events.OnBattleBegins.Invoke);
            }
            else
            {
                Events.OnBattleBegins.Invoke();
            }
        }

        // Finaliza la batalla
        private void FinishBattleWithVictory() => FinishBattle();


        public void FinishBattle(bool victory = true)
        {
            Events.OnBattleEnds.Invoke(victory);
            foreach (var speller in enemies)
            {
                if(speller != null)
                    Destroy(speller.gameObject);
            }
            enemies.Clear();
        }

        // Elimina un enemigo de la partida
        private void DefeatEnemy(int idx)
        {
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

        private void RemoveEnemy(int idx)
        {
            Events.OnDefeatEnemy.RemoveListener(DefeatEnemy);
        }

        // Define la acción que se ejecutará la proxima vez que se termine un diálogo
        private void SetDialogueEventHandler(Action action)
        {
            action.Invoke();
            dialogueManager.EndDialogueEvent -= () => SetDialogueEventHandler(action);
        }

        #endregion

        public void PauseBattle(bool pause)
        {
            Events.OnPauseBattle.Invoke(pause);
            Time.timeScale = pause ? 0.0f : 1.0f;
            
        }

        
    } 
}
