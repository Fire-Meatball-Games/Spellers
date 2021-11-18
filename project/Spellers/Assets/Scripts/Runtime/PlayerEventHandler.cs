using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CustomEventSystem;
using Runtime.DialogueSystem;

namespace Runtime
{
    public class PlayerEventHandler : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            SpellerBattle battle = FindObjectOfType<SpellerBattle>();
            if (GameController.instance == null) return;
            CombatSettings settings = GameSettings.combatSettings;

            if(settings.dialogueHandlers != null)
            {
                foreach (DialogueEventHandler handler in settings.dialogueHandlers)
                {
                    handler.SetUp(FindObjectOfType<DialogueManager>());
                }
            }
            if(settings.endHandlers != null)
            {
                foreach (EndConditionHandler handler in settings.endHandlers)
                {
                    handler.SetUp(battle);
                }
            }
            
            if(settings.scoreHandlers != null)
            {
                foreach (ScoreEventHandler handler in settings.scoreHandlers)
                {
                    handler.SetUp(battle);
                }
            }
            
        }
    }


}