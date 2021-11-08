using Runtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Runtime.DialogueSystem;

namespace Runtime
{
    public class LevelSelector : MonoBehaviour
    {
        private static int last_dialogue_level_index = 0;
        private static int last_unlocked_level_index = 0;

        #region Public fields

        public List<Level> levels;

        #endregion

        #region Private fields

        // Nivel seleccionado
        private Level selectedLevel;

        // Indice del nivel que activará un diálogo al ser seleccionado
        private int currentDialogueTriggerIndex = 0;

        #endregion

        #region Events

        public delegate void OnSelectLevelDelegate(Level level, int index);
        public event OnSelectLevelDelegate OnSelectLevelEvent;

        #endregion

        #region Public Methods

        // Selecciona un nivel del modo historia
        public void SelectLevel(int index)
        {
            int level_idx = index - 1;
            if (level_idx < levels.Count)
            {
                // Si el nivel está desbloqueado:
                if(level_idx <= last_unlocked_level_index)
                {
                    selectedLevel = levels[index - 1];
                    OnSelectLevelEvent?.Invoke(selectedLevel, index);
                    // Si el dialogo del nivel aun no se ha mostrado
                    if (level_idx >= last_dialogue_level_index)
                    {
                        DialogueManager dialogueManager = FindObjectOfType<DialogueManager>();
                        last_dialogue_level_index = index;
                        dialogueManager.StartDialogue(selectedLevel.dialogue);                        
                    }                    
                }
                else
                {
                    // Accion al pulsar un nivel bloqueado
                }
            }                
            else 
            {
                 throw new System.ArgumentOutOfRangeException("LevelManagerError: Level " + index + " doesn't exist.");

            }           
        }


        // Carga el nivel seleccionado:
        public void PlayLevel()
        {
            GameController.instance.SetCombatSettings(selectedLevel.gameSettings);
            GameController.instance.LoadCombat();
        }

        #endregion

    } 
}
