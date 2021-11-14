using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Runtime.DialogueSystem;

namespace Runtime
{
    public class PlayerEventHandler : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            if (GameController.instance == null) return;
            CombatSettings settings = GameSettings.combatSettings;
            foreach (DialogueEventHandler handler in settings.dialogueHandlers)
            {
                handler.SetUp(FindObjectOfType<DialogueManager>());
            }
            foreach (EndConditionHandler handler in settings.endHandlers)
            {
                handler.SetUp(FindObjectOfType<SpellerBattle>());
            }

        }
    }
}