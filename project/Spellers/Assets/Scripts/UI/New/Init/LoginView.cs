using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using NetworkManagement;
using TMPro;
using PlayerManagement;
using GameManagement;

namespace UIManagement
{
    public class LoginView : View
    {        
        [SerializeField] private Button back_btn;
        [SerializeField] private Button submit_btn;
        [SerializeField] private TextMeshProUGUI message_text;
        [SerializeField] private TMP_InputField Username_inputField;
        [SerializeField] private TMP_InputField Password_inputField;

        private string submitted_playername;
        
        public override void Init()
        {
            back_btn.onClick.AddListener(ViewManager.ShowLast);
            submit_btn.onClick.AddListener(Submit);
        }


        public void Submit()
        {
            string username = Username_inputField.text;
            string password = Password_inputField.text;

            if(string.IsNullOrEmpty(username))
            {
                message_text.text = "Introduce un nombre de usuario";
            }
            else if(string.IsNullOrEmpty(password))
            {
                message_text.text = "Introduce una contraseña";
            }
            else
            {
                submitted_playername = username;
                PlayFabNetworkManager.Login(username, password, CompleteLogin, ShowErrorMessage);
            }
        }

        private void CompleteLogin(string playerId)
        {
            PlayFabNetworkManager.GetInventory(OnGetCurrency);            
            message_text.text = "Bienvenid@ " + submitted_playername;
            if(Player.instance != null)
            {
                Player.instance.PlayerName = submitted_playername;
                Player.instance.Id = playerId;
            }

           
        }

        private void OnGetCurrency(int currency)
        {
            if(Player.instance != null)
            {
                Player.instance.Coins = currency;
            }
            GoToMainMenu();
        }
        private void ShowErrorMessage(string error)
        {
            message_text.text = error;
        }

        public override void Hide()
        {
            base.Hide();
            message_text.text = "";
            Username_inputField.text = "";
            Password_inputField.text = "";
        }

        private void GoToMainMenu()
        {
            if(GameManager.instance != null)
            {
                GameManager.instance.UnloadScene(SceneIndexes.TITLE_SCREEN);
                GameManager.instance.LoadSceneAsync(SceneIndexes.MAIN_MENU);
            }
        }
    }
}
