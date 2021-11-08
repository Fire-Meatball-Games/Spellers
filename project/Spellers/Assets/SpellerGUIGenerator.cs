using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CustomEventSystem;

namespace Runtime
{
    namespace CombatSystem
    {
        namespace UI
        {
            public class SpellerGUIGenerator : MonoBehaviour
            {
                public RectTransform enemyGUIList;
                public RectTransform playerGUIDisplay;
                public GameObject spellerNPCGUI_prefab;
                public GameObject spellerPlayerGUI_prefab;

                private void Awake()
                {
                    SpellerBattle battle = GetComponent<SpellerBattle>();
                    Events.OnJoinEnemy.AddListener(SetUpSpellerNPCGUI);
                    Events.OnJoinPlayer.AddListener(SetUpSpellerPlayerGUI);
                }

                private void SetUpSpellerPlayerGUI()
                {
                    SpellerGUI gui = Instantiate(spellerPlayerGUI_prefab, playerGUIDisplay).GetComponent<SpellerGUI>();
                    gui.SetUpPlayer();
                }

                private void SetUpSpellerNPCGUI(int idx)
                {
                    SpellerGUI gui = Instantiate(spellerNPCGUI_prefab, enemyGUIList).GetComponent<SpellerGUI>();
                    gui.SetUp(idx);
                }
            }  
        }
    }

}