using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab.ClientModels;
using PlayFab;
using System;

namespace NetworkManagement
{
    public class PlayFabRegister
    {
        public event Action<string> OnSuccess;
        public event Action<string> OnFailure;
        private string Username;
        public void Register(string username, string password){
            Username = username;
            var request = new RegisterPlayFabUserRequest{
                DisplayName = username,
                Username = username,
                Password = password,
                RequireBothUsernameAndEmail = false                
            };
            PlayFabClientAPI.RegisterPlayFabUser(request, OnRegisterSuccess, OnRegisterFailure);
        }

        private void OnRegisterSuccess(RegisterPlayFabUserResult result)
        {
            Debug.Log("Playfab: Register succesfully");
            OnSuccess?.Invoke(result.PlayFabId);
        }

        private void OnRegisterFailure(PlayFabError error)
        {
            Debug.Log("Playfab: Error while register");
            OnFailure?.Invoke(error.ErrorMessage);
        }
    }

}
