using PlayFab;
using PlayFab.ClientModels;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;

[System.Serializable]
public class InitialUserData
{
    public int initCoins;
    public bool tutorialEnabled;
}



public class PlayfabLogin : MonoBehaviour
{

    [Header("Registro")]
    [Header("Interfaz")]    

    public RectTransform register_layout;
    public TextMeshProUGUI register_message_text;
    public TMP_InputField register_username_input;
    public TMP_InputField register_password_input;
    public Button register_panel_button;
    public Button register_button;
    public Button register_back_btn;


    [Header("Inicio de sesion")]

    public RectTransform login_layout;
    public TextMeshProUGUI login_message_text;
    public TMP_InputField login_username_input;
    public TMP_InputField login_password_input;

    public Button login_panel_button;
    public Button login_button;
    public Button login_back_btn;

    private void Awake()
    {        
        register_button.onClick.AddListener(Register);
        login_button.onClick.AddListener(Login);
        register_back_btn.onClick.AddListener(ReturnToInit);
        login_back_btn.onClick.AddListener(ReturnToInit);
        register_panel_button.onClick.AddListener(ShowRegister);
        login_panel_button.onClick.AddListener(ShowLogin);
        login_layout.gameObject.SetActive(false);
        register_layout.gameObject.SetActive(false);
    }

    public void Register()
    {
        var request = new RegisterPlayFabUserRequest{
            DisplayName = register_username_input.text,
            Username = register_username_input.text,
            Password = register_password_input.text,
            RequireBothUsernameAndEmail = false
        };
        PlayFabClientAPI.RegisterPlayFabUser(request, OnRegisterSuccess, OnRegisterError);
    }

    public void Login()
    {
        var request = new LoginWithPlayFabRequest {
            Username = login_username_input.text,
            Password = login_password_input.text,                              
        };
        PlayFabClientAPI.LoginWithPlayFab(request, OnLoginSuccess, OnLoginError);
    }

    private void OnRegisterSuccess(RegisterPlayFabUserResult result)
    {
        register_message_text.text = "Registered and logged in";

    }
    
    private void OnLoginSuccess(LoginResult result)
    {
        login_message_text.text = "Logged in";
    }

    private void OnLoginError(PlayFabError error)
    {
        login_message_text.text = error.ErrorMessage;
    }

    private void OnRegisterError(PlayFabError error)
    {
        register_message_text.text = error.ErrorMessage;
    }

    private void OnError(PlayFabError error)
    {
        Debug.Log(error.ErrorMessage);
    }

    private void ShowLogin()
    {
        login_layout.gameObject.SetActive(true);
    }

    private void ShowRegister()
    {
        register_layout.gameObject.SetActive(true);
    }

    private void ReturnToInit()
    {
        register_layout.gameObject.SetActive(false);
        login_layout.gameObject.SetActive(false);
    }

}