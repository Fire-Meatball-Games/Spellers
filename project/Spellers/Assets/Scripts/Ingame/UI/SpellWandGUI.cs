using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SpellSystem;
using TMPro;
using CustomEventSystem;

namespace Ingame.UI
{
    public class SpellWandGUI: MonoBehaviour
    {
        #region Public variables
        public GameObject SpellLauncher_prefab;
        public GameObject content;
        private List<GameObject> spellLaunchers;
        #endregion

        #region Unity CallBacks and public methods
        public void Awake()
        {
            spellLaunchers = new List<GameObject>();            
        }

        private void OnEnable()
        {
            Events.OnCompleteWord.AddListener(SetUp);
        }

        private void OnDisable()
        {
            Events.OnCompleteWord.RemoveListener(SetUp);
        }
       

        #endregion

        #region Private Methods

        private void SetUp()
        {

        }

        private void DisableButtons()
        {
            foreach (var item in spellLaunchers)
            {
                item.SetActive(false);
            }
        }

        private void LaunchSpellToTarget(int targetIdx)
        {            
            FindObjectOfType<SpellerPlayer>().LaunchSpell();
            DisableButtons();
        }

        private void LaunchSpell()
        {
            FindObjectOfType<SpellerPlayer>().LaunchSpell();
            DisableButtons();
        }
        
        #endregion
    }

}