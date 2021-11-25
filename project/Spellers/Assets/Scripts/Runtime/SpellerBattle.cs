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

        public int currentScore;
        #endregion

        #region Initialization
        private void Awake()
        {
            enemies = new List<SpellerNPC>();
            currentScore = 3;
        }

        private void OnEnable()
        {
            Events.OnDefeatPlayer.AddListener(FinishBattleWithLose);
            Events.OnDefeatEnemy.AddListener(DefeatEnemy);
            Events.OnEndCountDown.AddListener(BeginBattle);
        }

        private void OnDisable()
        {
            Events.OnDefeatPlayer.RemoveListener(FinishBattleWithLose);
            Events.OnDefeatEnemy.RemoveListener(DefeatEnemy);
            Events.OnEndCountDown.RemoveListener(BeginBattle);
        }

        #endregion

        #region Private Methods

        // A�ade al jugador
        public void AddPlayer(SpellerPlayer player)
        {
            this.player = player;
            Events.OnJoinPlayer.Invoke();
        }

        // A�ade un enemigo a la partida
        public void AddEnemy(SpellerNPC spellerNPC, int idx)
        {
            enemies.Add(spellerNPC);
            Events.OnJoinEnemy.Invoke(idx);
        }

        // Comienza la batalla
        private void BeginBattle()
        {
            Time.timeScale = 1f;
            //if (GameController.instance == null) { Events.OnBattleBegins.Invoke(); return; }
            
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
        private void FinishBattleWithLose() => FinishBattle(false);


        public void FinishBattle(bool victory = true)
        {            
            enemies.Clear();
            Dialogue dialogue = GameSettings.combatSettings.end_dialogue;
            Debug.Log(dialogue);
            if (dialogue != null && victory)
            {
                dialogueManager = FindObjectOfType<DialogueManager>();
                FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
                dialogueManager.EndDialogueEvent += () => SetDialogueEventHandler(() => Events.OnBattleEnds.Invoke(victory));
            }
            else
            {
                Events.OnBattleEnds.Invoke(victory);
            }

            if (GameSettings.currentLevel >= 0 && victory)
            {
                if (GameSettings.combatSettings.scoreHandlers == null)
                    currentScore = ((player.stats.Health - 10) / 30) + 1;
                Debug.Log("Establecida la puntuaci�n del nivel " + GameSettings.currentLevel + " a " + currentScore);
                PlayerSettings.SetLevelScore(GameSettings.currentLevel, currentScore);
            }
        }

        // Elimina un enemigo de la partida
        private void DefeatEnemy(int idx)
        {
            if(enemies.Count > idx && enemies[idx] != null)
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
        }

        private void RemoveEnemy(int idx)
        {
            Events.OnDefeatEnemy.RemoveListener(DefeatEnemy);
        }

        // Define la acci�n que se ejecutar� la proxima vez que se termine un di�logo
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
