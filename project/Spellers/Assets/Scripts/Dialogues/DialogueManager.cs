using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DialogueSystem
{
    public class DialogueManager : MonoBehaviour
    {
        private Dialogue dialogue;
        private int currentLineIndex;

        public delegate void DialogueDelegate();
        public delegate void LoadDialogueLineDelegate(DialogueLine line);

        public event DialogueDelegate StartDialogueEvent;
        public event DialogueDelegate EndDialogueEvent;
        public event LoadDialogueLineDelegate LoadDialogueLineEvent;


        public void StartDialogue(Dialogue dialogue)
        {
            Time.timeScale = 0.0f;
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
            Time.timeScale = 1.0f;
            EndDialogueEvent?.Invoke();
            dialogue = null;
        }
    }

}