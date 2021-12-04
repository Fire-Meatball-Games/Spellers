using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Ingame
{
    public abstract class GameBoard : MonoBehaviour
    {
        [SerializeField] protected RectTransform rectTransform;

        private event Action OnSuccess = delegate{};
        private event Action OnFail = delegate{};

        public abstract void Generate();
        public void AddSuccessListener(Action action){ OnSuccess += action;}
        public void AddFailListener(Action action){OnFail += action;}

        protected void Success() => OnSuccess?.Invoke();
        protected void Fail() => OnFail?.Invoke();
    }

}
