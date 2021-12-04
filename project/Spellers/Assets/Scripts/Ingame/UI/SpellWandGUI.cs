using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SpellSystem;
using TMPro;
using CustomEventSystem;

namespace Ingame.UI
{
    public class SpellWandGUI: SpellPlayerGUI
    {
        #region Inspector variables
        [SerializeField] private Button launchSpellButton;

        #endregion

        #region Private Fields

        #endregion

        #region Public methods

        public override void SetUp(SpellerPlayer spellerPlayer)
        {
            base.SetUp(spellerPlayer);
            launchSpellButton.onClick.AddListener(player.LaunchSpell);
            launchSpellButton.onClick.AddListener(Hide);
        }
        #endregion

        #region Private Methods
        
        #endregion
    }

}