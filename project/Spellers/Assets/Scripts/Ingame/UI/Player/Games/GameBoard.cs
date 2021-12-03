using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Ingame
{
    public abstract class GameBoard : MonoBehaviour
    {
        [SerializeField] private RectTransform rectTransform;

        private event Action OnSuccess = delegate{};
        private event Action OnFail = delegate{};

        public abstract void Generate();
        public void SetSuccessListener(Action action){ OnSuccess += action;}
        public void SetFailListener(Action action){OnFail += action;}

        protected void Success() => OnSuccess?.Invoke();
        protected void Fail() => OnFail?.Invoke();
    }

}
