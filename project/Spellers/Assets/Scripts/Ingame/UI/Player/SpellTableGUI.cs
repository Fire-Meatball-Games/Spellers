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
            Events.OnSelectSpellSlot.AddListener(BookToBoard);     
            Events.OnSelectMinigame.AddListener(BookToBoard);

            Events.OnCompleteGame.AddListener(BoardToWand);

            Events.OnFailGame.AddListener(BoardToBook);
            Events.OnCompleteStopWandGame.AddListener(BoardToBook);
            Events.OnCompletePotionsGame.AddListener(BoardToBook);
            Events.OnCompleteFlipCardsGame.AddListener(BoardToBook);
            Events.OnTimerEnds.AddListener(BoardToBook);

            Events.OnPlayerUseSpell.AddListener(WandToBook);
        }

        private void OnDisable() 
        {
            Events.OnSelectSpellSlot.RemoveListener(BookToBoard);      
            Events.OnSelectMinigame.RemoveListener(BookToBoard);

            Events.OnCompleteGame.RemoveListener(BoardToWand);

            Events.OnFailGame.RemoveListener(BoardToBook);
            Events.OnCompleteStopWandGame.RemoveListener(BoardToBook);
            Events.OnCompletePotionsGame.RemoveListener(BoardToBook);
            Events.OnCompleteFlipCardsGame.RemoveListener(BoardToBook);
            
            Events.OnTimerEnds.RemoveListener(BoardToBook);

            Events.OnPlayerUseSpell.RemoveListener(WandToBook);
        }

        public void Active()
        {
            Debug.Log("UI Game activada");
            bookGUI.Show();
        }

        private void BoardToBook()
        {
            boardGUI.Hide();
            bookGUI.Show();
        }

        private void BookToBoard()
        {
            bookGUI.Hide();
            boardGUI.Show();
        }

        private void BoardToWand()
        {
            boardGUI.Hide();
            wandGUI.Show();
        }

        private void WandToBook()
        {
            wandGUI.Hide();
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