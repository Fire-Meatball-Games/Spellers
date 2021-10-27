using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SpellSystem;

namespace Runtime.CombatSystem
{
    public class SpellTableGUI : MonoBehaviour
    {
        public GameObject pnl_table;
        public GameObject pnl_board;
        public SpellerPlayer speller;
        public List<Button> spellSlotButtons;

        public void Awake()
        {
            for (int i = 0; i < spellSlotButtons.Count; i++)
            {
                // Esto evita un error que no entiendo
                int idx = i;
                spellSlotButtons[i].onClick.AddListener(() => speller.SelectSpell(idx));
            }
            EnableTablePanel();
            speller.board.OnCompleteWordEvent += EnableTablePanel;
            speller.table.OnSelectSlot += EnableBoardPanel;
            speller.table.OnChangeSlot += SetText;
        }        

        private void EnableTablePanel()
        {
            pnl_board.SetActive(false);
            pnl_table.SetActive(true);
        }

        private void EnableBoardPanel()
        {
            pnl_board.SetActive(true);
            pnl_table.SetActive(false);
        }

        private void SetText(int idx, string text)
        {
            spellSlotButtons[idx].GetComponentInChildren<Text>().text = text;
        }
    }

}