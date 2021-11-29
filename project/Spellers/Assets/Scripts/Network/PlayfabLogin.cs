using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using System;

namespace NetworkManagement
{
    public class PlayFabLogin
    {
        public event Action<string> OnSuccess;
        public event Action<string> OnFailure;

        public void Login(string username, string password)
        {
            if(string.IsNullOrEmpty(PlayFabSettings.staticSettings.TitleId))
            {
                PlayFabSettings.staticSettings.TitleId = "SPELLERS";
            }
            var request = new LoginWithPlayFabRequest {
                Username =  username,
                Password = password,
            };
            PlayFabClientAPI.LoginWithPlayFab(request, OnLoginSuccess, OnLoginFailure);
        }

        private void OnLoginSuccess(LoginResult result)
        {
            Debug.Log("Playfab: Login successfully");
            OnSuccess?.Invoke(result.PlayFabId);
        }

        private void OnLoginFailure(PlayFabError error)
        {
            Debug.Log("Playfab: Error while login");
            OnFailure?.Invoke(error.ErrorMessage);
        }
    }
}
