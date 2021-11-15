using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Runtime.CombatSystem;
using SpellSystem;
using Runtime.DialogueSystem;

namespace Runtime
{
    [System.Serializable]
    public class CombatSettings
    {
        // Detalles
        [SerializeField] public List<SpellerNPCSettings> speller_Settings;
        public Dialogue init_dialogue;
        public Dialogue end_dialogue;

        [SerializeField] public List<DialogueEventHandler> dialogueHandlers;
        [SerializeField] public List<EndConditionHandler> endHandlers;
        [SerializeField] public List<ScoreEventHandler> scoreHandlers;


    } 

    [System.Serializable]
    public class DialogueEventHandler
    {
        [SerializeField] public PlayerEvent playerEvent;
        [SerializeField] public int value;
        [SerializeField] public Dialogue dialogue;

        private DialogueManager dialogueManager;

        public void SetUp(DialogueManager manager)
        {
            dialogueManager = manager;
            playerEvent.AddListener(Listener);
        }

        private void Listener(int value)
        {
            if (this.value == value)
            {
                dialogueManager.StartDialogue(dialogue);
            }                
        }
    }

    [System.Serializable]
    public class EndConditionHandler
    {
        [SerializeField] public PlayerEvent playerEvent;
        [SerializeField] public int value;
        [SerializeField] public bool win;

        private SpellerBattle battle;

        public void SetUp(SpellerBattle battle)
        {            
            this.battle = battle;
            playerEvent.AddListener(Listener);
        }

        private void Listener(int value)
        {
            if (this.value == value)
            {
                battle.FinishBattle(win);
            }
        }
    }

    [System.Serializable]
    public class ScoreEventHandler
    {
        [SerializeField] public PlayerEvent playerEvent;
        [SerializeField] public int value;
        [SerializeField] public bool removeStarCondition;
        [SerializeField] public int stars;

        private SpellerBattle battle;

        public void SetUp(SpellerBattle battle)
        {
            Debug.Log("E");
            this.battle = battle;
            playerEvent.AddListener(Listener);
        }

        private void Listener(int value)
        {
            Debug.Log(value + "/" + value);
            if (this.value == value)
            {
                Debug.Log("Estrellas: " + stars);
                battle.currentScore = stars;
            }
        }
    }


}

