using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NetworkManagement
{
    public class PlayFabAccountData
    {
        public event Action<string> OnSuccess;
        public event Action<string> OnFailure;
    }
}


