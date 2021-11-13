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

        // Añade al jugador
        public void AddPlayer(SpellerPlayer player)
        {
            this.player = player;
            player.SetSettings();
            Events.OnDefeatPlayer.AddListener(() => FinishBattle(false));
            Events.OnJoinPlayer.Invoke();
            Events.OnEndCountDown.AddListener(BeginBattle);
        }

        // Añade un enemigo a la partida
        public void AddEnemy(SpellerNPC spellerNPC, int idx)
        {
            enemies.Add(spellerNPC);
            Events.OnDefeatEnemy.AddListener(DefeatEnemy);
            Events.OnJoinEnemy.Invoke(idx);
        }

        #endregion

        #region Private Methods

        // Comienza la batalla
        private void BeginBattle()
        {
            if (GameController.instance == null) { Events.OnBattleBegins.Invoke(); return; }

            // Si hay dialogo inicial lo carga
            Dialogue dialogue = GameController.instance.game_settings.init_dialogue;
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
        private void FinishBattle(bool victory = true)
        {
            Events.OnBattleEnds.Invoke(victory);
            foreach (var speller in enemies)
            {
                Destroy(speller.gameObject);
            }
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
