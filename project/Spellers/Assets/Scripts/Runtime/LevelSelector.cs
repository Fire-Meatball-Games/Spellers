using Runtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Runtime
{
    public class LevelSelector : MonoBehaviour
    {

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
            if (index <= levels.Count)
            {
                selectedLevel = levels[index - 1];
                GameController.instance.SetCombatSettings(selectedLevel.gameSettings);
                OnSelectLevelEvent?.Invoke(selectedLevel, index);
            }
        }

        public void PlayLevel()
        {
            GameController.instance.LoadCombat();
        }

        #endregion

    } 
}
