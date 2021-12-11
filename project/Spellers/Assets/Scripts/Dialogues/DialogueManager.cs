using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DialogueSystem
{
    public class DialogueManager : MonoBehaviour
    {
        private Dialogue dialogue;
        private int currentLineIndex;
        public event Action StartDialogueEvent = delegate{};
        public event Action EndDialogueEvent = delegate{};
        private event Action dialogueCallback = delegate{};
        public event Action<DialogueLine> LoadDialogueLineEvent = delegate{};


        public void StartDialogue(Dialogue dialogue, Action dialogueCallback = null)
        {
            this.dialogueCallback = dialogueCallback;
            this.dialogue = dialogue;
            currentLineIndex = 0;
            StartDialogueEvent?.Invoke();
            LoadNextLine();
        }

        public void LoadNextLine()
        {
            if (currentLineIndex >= dialogue.GetNumLines())
                EndDialogue();
            else
            {
                DialogueLine line = dialogue.GetLine(currentLineIndex);
                LoadDialogueLineEvent?.Invoke(line);
                currentLineIndex++;
            }
        }

        public void EndDialogue()
        {
            EndDialogueEvent?.Invoke();
            dialogueCallback?.Invoke();
            dialogueCallback = null;
            dialogue = null;
        }
    }

}