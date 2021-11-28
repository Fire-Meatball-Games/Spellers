using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UIManagement
{
    public class SpellDeckView : MenuView
    {
        [SerializeField] private PlayerDecksGUI playerDecksGUI;
        [SerializeField] private SpellCollectionGUI spellCollectionGUI;

        public override void Init()
        {
            playerDecksGUI.Init();
            spellCollectionGUI.Init();
        }
    }

}