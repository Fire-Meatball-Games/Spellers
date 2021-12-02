using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Runtime.CombatSystem;
using System;
using CustomEventSystem;
using Runtime.DialogueSystem;
using PlayerManagement;

namespace Runtime
{
    public class BattleManager : MonoBehaviour
    {
        #region Inspector fields
        [SerializeField] private SpellerSpawner spawner;

        #endregion

        #region Public variables
        private SpellerPlayer player;
        private SpellerNPC enemy;
        private DialogueManager dialogueManager;
        public int currentScore;

        #endregion

        #region Initialization
        private void Awake()
        {
            SetUpPlayer();
        }

        private void OnEnable()
        {
            Events.OnDefeatPlayer.AddListener(FinishBattleWithLose);
            Events.OnEndCountDown.AddListener(BeginBattle);
        }

        private void OnDisable()
        {
            Events.OnDefeatPlayer.RemoveListener(FinishBattleWithLose);
            Events.OnEndCountDown.RemoveListener(BeginBattle);
        }

        private void SetUpPlayer()
        {
            player = spawner.GeneratePlayer();
            PlayerSettings settings = PlayerSettings.instance;
            
        }

        #endregion

        #region Private Methods

        // Comienza la batalla
        private void BeginBattle()
        {
            
        }

        // Finaliza la batalla
        private void FinishBattleWithLose() => FinishBattle(false);


        public void FinishBattle(bool victory = true)
        {            
           
        }

        #endregion
        
    } 
}
