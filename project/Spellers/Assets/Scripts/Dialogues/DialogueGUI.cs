using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Tweening;

namespace DialogueSystem 
{
    public class DialogueGUI : MonoBehaviour
    {
        [SerializeField] private DialogueManager dialogueManager;
        [SerializeField] private RectTransform layout;
        [SerializeField] private TextMeshProUGUI dialogue_text;
        [SerializeField] private TextMeshProUGUI characterName_text;
        [SerializeField] private Image characterSprite_image;
        [SerializeField] private Button dialogue_button;  
        [SerializeField] private float textSpeed;      
        
        private EffectBuilder showEffects, hideEffects;

        private bool coroutineRunning;

        public void Awake()
        {            
            showEffects = new EffectBuilder(this)
            .AddEffect(new ScreenSlideEffect(layout, Vector2.down * 0.5f, Vector2.zero, 1.1f, 0.2f))
            .AddEffect(new EnableEffect(layout.gameObject, 0, true));

            hideEffects = new EffectBuilder(this)
            .AddEffect(new ScreenSlideEffect(layout, Vector2.zero, Vector2.down * 0.4f, 1f, 0.2f))
            .AddEffect(new EnableEffect(layout.gameObject, 0.2f, false));

            dialogueManager.StartDialogueEvent += ShowView;
            dialogueManager.LoadDialogueLineEvent += StartDialogueLine;
            dialogueManager.EndDialogueEvent += HideView;

            dialogue_button.onClick.AddListener(OnClickDialogueButton);

            layout.gameObject.SetActive(false);
        }

        private void ShowView()
        {
            showEffects.ExecuteEffects();
        }

        private void HideView()
        {
            hideEffects.ExecuteEffects();
        }

        private void OnClickDialogueButton()
        {
            if(coroutineRunning)
            {
                StopAllCoroutines();
                coroutineRunning = false;
            }
            else
            {
                dialogueManager.LoadNextLine();
            }
        }


        private void StartDialogueLine(DialogueLine line)
        {
            StartCoroutine(ShowTextCorroutine(line.Text));
            characterName_text.text = line.Character.CharacterName;
            characterSprite_image.sprite = line.Character.sprite;
        }

        private IEnumerator ShowTextCorroutine(string line)
        {
            coroutineRunning = true;
            int index = 0;
            float time = 0;
            dialogue_text.text = "";
            while(index < line.Length)
            {
                time += Time.deltaTime;
                index = Mathf.RoundToInt(time * textSpeed);
                dialogue_text.text = line.Substring(0, index);                
                yield return null;
            }
            coroutineRunning = false;
        }
    } 
}
