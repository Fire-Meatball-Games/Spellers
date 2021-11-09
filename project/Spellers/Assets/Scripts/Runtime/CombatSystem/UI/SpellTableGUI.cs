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
        public GameObject pnl_book;
        public GameObject pnl_board;
        public GameObject pnl_wand;
        #endregion

        #region private Fields
        private GameObject current_panel;
        #endregion

        #region Unity CallBacks and public methods
        public void Awake()
        {
            pnl_board.SetActive(false);
            pnl_wand.SetActive(false);
            EnablePanel(pnl_book);
            Events.OnCompleteWord.AddListener(() => EnablePanel(pnl_wand));
            Events.OnSelectSpellSlot.AddListener((_) => EnablePanel(pnl_board));
            Events.OnPlayerUseSpell.AddListener(() => EnablePanel(pnl_book));
            Events.OnCheckKey.AddListener((x,y,hit) => { if (!hit) EnablePanel(pnl_book); });

        }

        private void SubscribeToEvents()
        {
            // WAND:
            //btn_spell.onClick.AddListener(() => player.LaunchSpell());
            //btn_spell.onClick.AddListener(() => btn_spell.gameObject.SetActive(false));
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
        #endregion
    }

}