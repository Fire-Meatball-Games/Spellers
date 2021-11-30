using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using System;

namespace NetworkManagement
{
    public class PlayFabInventory
    {   
        public event Action<int> OnSuccess;
        public event Action<string> OnFailure;
     
        public void GetItems(string playerId)
        {
            var request = new GetPlayerCombinedInfoRequest
            {
                PlayFabId = playerId,
                InfoRequestParameters = new GetPlayerCombinedInfoRequestParams
                {
                    GetUserVirtualCurrency = true
                }
            };

            PlayFabClientAPI.GetPlayerCombinedInfo(request, OnGetItemsSuccess, OnError);

        }

        private void OnGetItemsSuccess(GetPlayerCombinedInfoResult result)
        {
            int currency = result.InfoResultPayload.UserVirtualCurrency["SC"];
            Debug.Log("Currency: " + currency);
            OnSuccess?.Invoke(currency);
        }

        private void OnError(PlayFabError obj)
        {
            throw new NotImplementedException();
        }
    }
}