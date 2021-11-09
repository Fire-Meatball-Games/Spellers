using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SpellSystem;
using TMPro;
using CustomEventSystem;

namespace Runtime.CombatSystem.UI
{
    public class SpellWandGUI: MonoBehaviour
    {
        #region Public variables
        public Button spellButton;
        #endregion

        #region Unity CallBacks and public methods
        public void Awake()
        {
            Events.OnCompleteWord.AddListener(() => SetActiveButton(true));
            spellButton.onClick.AddListener(LaunchSpell);
        }

        public void SetActiveButton(bool state)
        {
            spellButton.interactable = state;
        }

        #endregion

        #region Private Methods

        private void LaunchSpell()
        {
            FindObjectOfType<SpellerPlayer>().LaunchSpell();
            SetActiveButton(false);
        }
        
        #endregion
    }

}