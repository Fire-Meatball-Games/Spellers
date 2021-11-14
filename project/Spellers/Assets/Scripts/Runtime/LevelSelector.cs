using Runtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Runtime.DialogueSystem;
using CustomEventSystem;

namespace Runtime
{
    public class LevelSelector : MonoBehaviour
    {
        public bool load_level_dialogue = true;
        public int last_unlocked_level_index = 0;

        #region Public fields

        public List<Level> levels;
        public int selectedLevel = -1;

        #endregion

        #region Public Methods

        private void Start()
        {
            last_unlocked_level_index = PlayerSettings.lastLevelUnlocked;
        }

        // Selecciona un nivel del modo historia
        public void SelectLevel(int index)
        {
            if (index >= levels.Count)
                return;

            if (index <= last_unlocked_level_index)
            {
                selectedLevel = index;
                Events.OnSelectLevel.Invoke(index);
                // Si el dialogo del nivel aun no se ha mostrado
                if (load_level_dialogue && index == last_unlocked_level_index)
                {
                    LoadLevelDialogue();                    
                }
            }      
        }

        public void UnselectLevel()
        {
            selectedLevel = -1;
            Events.OnDeselectLevel.Invoke();
        }

        public Level GetSelectedLevel() => levels[selectedLevel];

        // Carga el nivel seleccionado:
        public void PlayLevel()
        {
            if(selectedLevel != -1)
            {
                GameController.instance.SetCombatSettings(GetSelectedLevel().gameSettings);
                GameController.instance.LoadCombat();
            }            
        }

        #endregion

        private void LoadLevelDialogue()
        {
            DialogueManager dialogueManager = FindObjectOfType<DialogueManager>();
            load_level_dialogue = false;
            dialogueManager.StartDialogue(GetSelectedLevel().map_dialogue);
        }

    } 
}
