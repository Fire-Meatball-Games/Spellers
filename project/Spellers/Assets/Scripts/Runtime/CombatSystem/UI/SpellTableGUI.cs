using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using CustomEventSystem;


namespace Runtime.CombatSystem.UI
{
    public class SpellTableGUI : MonoBehaviour
    {
        #region Public variables
        public GameObject pnl_table;
        public GameObject pnl_board;
        public GameObject pnl_wand;
        public List<Button> spellSlotButtons;
        public Button btn_spell;
        #endregion

        #region private Fields
        private GameObject current_panel;
        private SpellerPlayer player;
        #endregion

        #region Unity CallBacks and public methods
        public void Awake()
        {
            //spellSlotButtons = new List<Button>();            
            EnablePanel(pnl_table);
            Events.OnJoinPlayer.AddListener(() => SubscribeToEvents());
        }

        public void SubscribeToEvents()
        {
            player = FindObjectOfType<SpellerPlayer>();
            for (int i = 0; i < spellSlotButtons.Count; i++)
            {
                int idx = i;
                spellSlotButtons[i].onClick.AddListener(() => player.SelectSpell(idx));
            }
            btn_spell.onClick.AddListener(() => player.LaunchSpell());
            btn_spell.onClick.AddListener(() => btn_spell.gameObject.SetActive(false));
            player.board.OnCompleteWordEvent += () => EnablePanel(pnl_wand);
            player.board.OnCompleteWordEvent += () => btn_spell.gameObject.SetActive(true);
            player.board.OnFailKeyEvent += () => EnablePanel(pnl_table);
            player.table.OnSelectSlot += () => EnablePanel(pnl_board);
            player.OnUseSpellEvent += () => EnablePanel(pnl_table);
            player.table.OnChangeSlot += SetText;
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