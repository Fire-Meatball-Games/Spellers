using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace DialogueSystem 
{
    public class DialogueGUI : MonoBehaviour
    {
        public TextMeshProUGUI dialogue_text;
        public TextMeshProUGUI characterName_text;
        public Image characterSprite_image;
        public Button dialogue_button;
        public GameObject dialogueRenderer;

        public void Awake()
        {
            DialogueManager manager = FindObjectOfType<DialogueManager>();
            manager.StartDialogueEvent += ShowView;
            manager.LoadDialogueLineEvent += StartDialogueLine;
            manager.EndDialogueEvent += HideView;
            dialogue_button.onClick.AddListener(() => manager.LoadNextLine());
            HideView();
        }

        private void ShowView()
        {
            dialogueRenderer.SetActive(true);
        }

        private void HideView()
        {
            dialogueRenderer.SetActive(false);
        }

        private void StartDialogueLine(DialogueLine line)
        {
            dialogue_text.text = line.Text;
            characterName_text.text = line.Character.CharacterName;
            characterSprite_image.sprite = line.Character.sprite;
        }
    } 
}
