using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using CustomEventSystem;


namespace Ingame.UI
{
    public class SpellTableGUI : MonoBehaviour
    {
        [SerializeField] private SpellBookGUI bookGUI;

        public void SetUp(SpellerPlayer player)
        {
            bookGUI.SetUp(player);
        }




        // #region Public variables
        // public GameObject pnl_book;
        // public GameObject pnl_board;
        // public GameObject pnl_wand;
        // #endregion

        // #region Unity CallBacks and public methods        

        // public void Start()
        // {
        //     pnl_book.SetActive(false);
        //     pnl_board.SetActive(false);
        //     pnl_wand.SetActive(false);
        // }

        // private void OnEnable()
        // {
        //     Events.OnBattleBegins.AddListener(SetBookView);
        //     Events.OnCompleteWord.AddListener(SetWandView);
        //     Events.OnSelectSpellSlot.AddListener(SetBoardView);
        //     Events.OnPlayerUseSpell.AddListener(SetBookView);
        //     Events.OnFailSpell.AddListener(SetBookView);
        // }

        // private void OnDisable()
        // {
        //     Events.OnBattleBegins.RemoveListener(SetBookView);
        //     Events.OnCompleteWord.RemoveListener(SetWandView);
        //     Events.OnSelectSpellSlot.RemoveListener(SetBoardView);
        //     Events.OnPlayerUseSpell.RemoveListener(SetBookView);
        //     Events.OnFailSpell.RemoveListener(SetBookView);
        // }

        // #endregion

        // #region Private Methods

        // private void SetBookView()
        // {
        //     pnl_book.SetActive(true);
        //     pnl_board.SetActive(false);
        //     pnl_wand.SetActive(false);
        // }

        // private void SetBoardView(int n)
        // {
        //     pnl_book.SetActive(false);
        //     pnl_board.SetActive(true);
        //     pnl_wand.SetActive(false);
        // }

        // private void SetWandView()
        // {
        //     pnl_book.SetActive(false);
        //     pnl_board.SetActive(false);
        //     pnl_wand.SetActive(true);
        // }


        // #endregion
    }

}