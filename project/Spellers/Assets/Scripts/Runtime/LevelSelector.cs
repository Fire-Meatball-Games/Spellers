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
        public static int last_dialogue_level_index = 0;
        public static int last_unlocked_level_index = 0;

        #region Public fields

        public List<Level> levels;
        public Level SelectedLevel;

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
                    SelectedLevel = levels[index - 1];
                    Events.OnSelectLevel.Invoke(level_idx);
                    // Si el dialogo del nivel aun no se ha mostrado
                    if (level_idx >= last_dialogue_level_index)
                    {
                        DialogueManager dialogueManager = FindObjectOfType<DialogueManager>();
                        last_dialogue_level_index = index;
                        dialogueManager.StartDialogue(SelectedLevel.map_dialogue);                        
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
            if(SelectedLevel != null)
            {
                GameController.instance.SetCombatSettings(SelectedLevel.gameSettings);
                GameController.instance.LoadCombat();
            }            
        }

        #endregion

    } 
}
