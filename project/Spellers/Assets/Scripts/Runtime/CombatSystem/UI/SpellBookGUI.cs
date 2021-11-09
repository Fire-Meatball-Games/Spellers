using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SpellSystem;
using TMPro;
using CustomEventSystem;

namespace Runtime.CombatSystem.UI
{
    public class SpellBookGUI : MonoBehaviour
    {
        #region Public variables
        public RectTransform book_content;
        public GameObject spellSlot_prefab;
        #endregion

        #region private Fields
        private List<GameObject> spellSlots;
        #endregion

        #region Unity CallBacks and public methods
        public void Awake()
        {
            spellSlots = new List<GameObject>();
            Events.OnGenerateSpellSlots.AddListener(SetUpSpellSlots);
        }


        #endregion

        #region Private Methods

        // Genera la lista de hechizos:
        private void SetUpSpellSlots(List<SpellUnit> spells)
        {            
            ShutDownSpellSlots();
            for (int i = 0; i < spells.Count; i++)
            {
                int idx = i;
                var spellSlot_go = Instantiate(spellSlot_prefab, book_content);
                spellSlot_go.GetComponentInChildren<Button>().onClick.AddListener(() => FindObjectOfType<SpellerPlayer>().SelectSpell(idx));
                SetLayoutSlot(spellSlot_go, spells[i]);
                spellSlots.Add(spellSlot_go);
            }          
        }

        // Destruye la lista de hechizos:
        private void ShutDownSpellSlots()
        {

        }

        // Pinta el layout del hechizo:
        private void SetLayoutSlot(GameObject go, SpellUnit spellUnit)
        {
            go.transform.Find("SpellName").GetComponent<TextMeshProUGUI>().SetText(spellUnit.spell.spellName);
        }
        
        #endregion
    }

}