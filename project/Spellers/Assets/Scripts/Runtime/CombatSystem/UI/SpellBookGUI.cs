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
        private SpellerPlayer player;
        #endregion

        #region Unity CallBacks and public methods
        public void Awake()
        {
            spellSlots = new List<GameObject>();
            Events.OnJoinPlayer.AddListener(() => SubscribeToEvents());
        }

        public void SubscribeToEvents()
        {
            player = FindObjectOfType<SpellerPlayer>();
        }

        #endregion

        #region Private Methods

        // Genera la lista de hechizos:
        private void SetUpSpellSlots(List<Spell> spells)
        {
            ShutDownSpellSlots();
            foreach (var spell in spells)
            {
                var spellSlot_go = Instantiate(spellSlot_prefab, book_content);
                SetLayoutSlot(spellSlot_go, spell);
                spellSlots.Add(spellSlot_go);
            }            
        }

        // Destruye la lista de hechizos:
        private void ShutDownSpellSlots()
        {

        }

        // Pinta el layout del hechizo:
        private void SetLayoutSlot(GameObject go, Spell spell)
        {
            go.transform.Find("SpellName").GetComponent<TextMeshProUGUI>().SetText(spell.spellName);
        }
        
        #endregion
    }

}