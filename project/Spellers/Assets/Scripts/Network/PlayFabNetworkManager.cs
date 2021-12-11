using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab.ClientModels;
using PlayFab;
using UnityEngine.UI;
using TMPro;
using PlayerManagement;
using Utils;
using System;

namespace NetworkManagement
{   

    public class PlayFabNetworkManager : MonoBehaviour
    {
        private static string _playerId;

        public static void Login(string username, string password, Action<string> OnSuccess, Action<string> OnError)
        {
            PlayFabLogin login = new PlayFabLogin();
            login.OnSuccess += playerId => _playerId = playerId;
            login.OnSuccess += OnSuccess;
            login.OnFailure += OnError;
            login.Login(username, password);
        }

        public static void Register(string username, string password, Action<string> OnSuccess, Action<string> OnError)
        {
            PlayFabRegister register = new PlayFabRegister();
            register.OnSuccess += playerId => _playerId = playerId;
            register.OnSuccess += OnSuccess;
            register.OnFailure += OnError;
            register.Register(username, password);
        }

        public static void GetInventory(Action<int> OnSuccess)
        {
            PlayFabInventory inventory = new PlayFabInventory();
            inventory.OnSuccess += OnSuccess;
            inventory.GetItems(_playerId);
        }
    }  
}