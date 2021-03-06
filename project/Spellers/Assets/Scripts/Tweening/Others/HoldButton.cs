using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Tweening
{
    public class HoldButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {
        public event Action OnHoldTime = delegate {};
        public float holdTime;
        public void OnPointerDown(PointerEventData eventData)
        {
            StartCoroutine(HoldCorroutine());
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            StopCoroutine(HoldCorroutine());
        }

        private IEnumerator HoldCorroutine()
        {
            yield return new WaitForSeconds(holdTime);
            OnHoldTime?.Invoke();
        }
    }
 
}
