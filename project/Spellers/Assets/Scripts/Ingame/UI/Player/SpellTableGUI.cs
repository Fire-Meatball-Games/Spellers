using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using CustomEventSystem;


namespace Ingame.UI
{
    //Gestiona el movimiento de pantallas de la interfaz de juego:
    public class SpellTableGUI : MonoBehaviour
    {
        [SerializeField] private SpellBookGUI bookGUI;
        [SerializeField] private BoardGUI boardGUI;
        [SerializeField] private SpellWandGUI wandGUI;

        private SpellerPlayer player;

        public void SetUp(SpellerPlayer player)
        {
            this.player = player;
            bookGUI.SetUp(player);
            boardGUI.SetUp(player);
            wandGUI.SetUp(player);
        }

        private void Awake() 
        {
            bookGUI.HideInstant();
            boardGUI.HideInstant();
            wandGUI.HideInstant();
        }

        private void OnEnable() 
        {
            Events.OnSelectSpellSlot.AddListener(bookGUI.Hide);
            Events.OnSelectSpellSlot.AddListener(boardGUI.Show);            

            Events.OnCompleteGame.AddListener(boardGUI.Hide);
            Events.OnCompleteGame.AddListener(wandGUI.Show);

            Events.OnFailGame.AddListener(boardGUI.Hide);
            Events.OnFailGame.AddListener(bookGUI.Show);

            Events.OnPlayerUseSpell.AddListener(wandGUI.Hide);
            Events.OnPlayerUseSpell.AddListener(bookGUI.Show);
        }

        private void OnDisable() 
        {
            Events.OnSelectSpellSlot.RemoveListener(bookGUI.Hide);
            Events.OnSelectSpellSlot.RemoveListener(boardGUI.Show);            

            Events.OnCompleteGame.RemoveListener(boardGUI.Hide);
            Events.OnCompleteGame.RemoveListener(wandGUI.Show);

            Events.OnFailGame.RemoveListener(boardGUI.Hide);
            Events.OnFailGame.RemoveListener(bookGUI.Show);

            Events.OnPlayerUseSpell.RemoveListener(wandGUI.Hide);
            Events.OnPlayerUseSpell.RemoveListener(bookGUI.Show);
        }

        public void Active()
        {
            Debug.Log("UI Game activada");
            bookGUI.Show();
        }


        // #endregion

        // #region Unity CallBacks and public methods        

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
    }

}