using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace Runtime.CombatSystem.UI
{
    public class SpellTableGUI : MonoBehaviour
    {
        #region Public variables
        public GameObject pnl_table;
        public GameObject pnl_board;
        public GameObject pnl_wand;
        public SpellerPlayer speller;
        public List<Button> spellSlotButtons;
        public Button btn_spell;
        #endregion

        #region private Fields
        private GameObject current_panel;
        #endregion

        #region Unity Callbacks
        public void Awake()
        {
            for (int i = 0; i < spellSlotButtons.Count; i++)
            {
                int idx = i;
                spellSlotButtons[i].onClick.AddListener(() => speller.SelectSpell(idx));
            }

            btn_spell.onClick.AddListener(() => speller.LaunchSpell());

            EnablePanel(pnl_table);
            speller.board.OnCompleteWordEvent += () => EnablePanel(pnl_wand);
            speller.board.OnFailKeyEvent += () => EnablePanel(pnl_table);
            speller.table.OnSelectSlot += () => EnablePanel(pnl_board);
            speller.OnUseSpellEvent += () => EnablePanel(pnl_table);
            speller.table.OnChangeSlot += SetText;
        }
        #endregion

        #region Private Methods

        // Activa un panel y desactiva el anterior
        private void EnablePanel(GameObject panel)
        {
            current_panel?.SetActive(false);
            panel.SetActive(true);
            current_panel = panel;
        }

        // Cambia el texto de uno de los hechizos
        private void SetText(int idx, string text)
        {
            spellSlotButtons[idx].GetComponentInChildren<Text>().text = text;
        }
        #endregion
    }

}