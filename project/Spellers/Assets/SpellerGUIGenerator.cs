using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Runtime
{
    namespace CombatSystem
    {
        namespace UI
        {
            public class SpellerGUIGenerator : MonoBehaviour
            {
                public Battle battle;
                public RectTransform enemyGUIList;
                public RectTransform playerGUIDisplay;
                public GameObject spellerNPCGUI_prefab;
                public GameObject spellerPlayerGUI_prefab;

                private void Awake()
                {
                    battle.OnAddSpellerNPCEvent += SetUpSpellerNPCGUI;
                    battle.OnSetSpellerPlayerEvent += SetUpSpellerPlayerGUI;
                }

                private void SetUpSpellerPlayerGUI(Speller speller)
                {
                    SpellerGUI gui = Instantiate(spellerPlayerGUI_prefab, playerGUIDisplay).GetComponent<SpellerGUI>();
                    gui.SetUp(speller);
                }

                private void SetUpSpellerNPCGUI(Speller speller)
                {
                    SpellerGUI gui = Instantiate(spellerNPCGUI_prefab, enemyGUIList).GetComponent<SpellerGUI>();
                    gui.SetUp(speller);
                }
            }  
        }
    }

}