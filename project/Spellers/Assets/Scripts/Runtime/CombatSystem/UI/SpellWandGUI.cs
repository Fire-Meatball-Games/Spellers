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
            for (int i = spellLaunchers.Count - 1; i >= 0; i--)
            {
                Destroy(spellLaunchers[i]);
            }
            spellLaunchers.Clear();

            bool offensive = FindObjectOfType<SpellerPlayer>().table.GetSelectedSpell().spell.offensive;
            if (offensive)
            {
                int n = FindObjectOfType<SpellerBattle>().enemies.Count;
                for (int i = 0; i < n; i++)
                {
                    int idx = i;
                    var go = Instantiate(SpellLauncher_prefab, content.transform);
                    RectTransform rt = go.GetComponent<RectTransform>();
                    rt.anchorMin = new Vector2(0, (1.0f / n) * idx);
                    rt.anchorMax = rt.anchorMin + new Vector2(1f, 1.0f / n);
                    idx = (idx + 2) % n;
                    go.GetComponent<Button>().onClick.AddListener(()=> LaunchSpellToTarget(idx));
                    spellLaunchers.Add(go);
                }
                
            }
            else
            {
                var go = Instantiate(SpellLauncher_prefab, content.transform);
                go.GetComponent<Button>().onClick.AddListener(LaunchSpell);
                spellLaunchers.Add(go);
            }
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
            FindObjectOfType<SpellerPlayer>().SetTarget(FindObjectOfType<SpellerBattle>().enemies[targetIdx], targetIdx);
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