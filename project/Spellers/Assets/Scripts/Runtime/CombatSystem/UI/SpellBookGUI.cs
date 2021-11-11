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
        private List<SpellSlotGUI> spellSlots;
        #endregion

        #region Unity CallBacks and public methods
        public void Awake()
        {
            spellSlots = new List<SpellSlotGUI>();
            Events.OnGenerateSpellSlots.AddListener(SetUpSpellSlots);
            Events.OnChangeSpellSlot.AddListener(SetLayoutSlot);
        }

        #endregion

        #region Private Methods

        // Genera la lista de hechizos:
        private void SetUpSpellSlots(List<SpellUnit> spells)
        {
            Debug.Log(spells.Count);
            ShutDownSpellSlots();
            for (int i = 0; i < spells.Count; i++)
            {
                int idx = i;
                SpellSlotGUI spellSlot = Instantiate(spellSlot_prefab, book_content).GetComponent<SpellSlotGUI>();
                spellSlot.AddListener(() => FindObjectOfType<SpellerPlayer>().SelectSpell(idx));
                spellSlots.Add(spellSlot);
                SetLayoutSlot(idx, spells[idx]);
            }          
        }

        // Destruye la lista de hechizos:
        private void ShutDownSpellSlots()
        {
            for (int i = spellSlots.Count - 1; i >= 0; i--)
            {
                Destroy(spellSlots[i].gameObject);
            }
            spellSlots.Clear();          
        }

        // Pinta el layout del hechizo:
        private void SetLayoutSlot(int idx, SpellUnit spellUnit)
        {
            spellSlots[idx].SetSpellGUI(spellUnit);
        }
        
        #endregion
    }

}