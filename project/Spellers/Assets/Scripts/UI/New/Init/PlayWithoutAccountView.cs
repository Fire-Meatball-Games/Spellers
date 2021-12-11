using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using GameManagement;
using PlayerManagement;

namespace UIManagement
{
    public class PlayWithoutAccountView : View
    {
        [SerializeField] private Button back_btn;
        [SerializeField] private Button submit_btn;
        [SerializeField] private TextMeshProUGUI message_text;
        [SerializeField] private TMP_InputField Username_inputField;
        
        public override void Init()
        {
            back_btn.onClick.AddListener(ViewManager.ShowLast);
            submit_btn.onClick.AddListener(Submit);
        }

        public void Submit()
        {
            string username = Username_inputField.text;

            if(string.IsNullOrEmpty(username))
            {
                message_text.text = "Introduce un nombre de usuario";
            }
            else
            {
                message_text.text = "Bienvenid@ " + username;
                if(Player.instance != null)
                {
                    Player.instance.PlayerName = username;
                }               

                if(GameManager.instance != null)
                {
                    GameManager.instance.UnloadScene(SceneIndexes.TITLE_SCREEN);
                    GameManager.instance.LoadSceneAsync(SceneIndexes.MAIN_MENU);                    
                }                
            }
        }
    }
}
