using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace UIManagement
{
    public class CardSection : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI title_txt;
        [SerializeField] private RectTransform rectTransform;

        private string tittle;
        private int maxItems;

        public void SetUp(string title, int maxItems = 0)
        {
            this.tittle = title;
            this.maxItems = maxItems;
        }

        public void AddToLayout(CardView card)
        {
            card.transform.SetParent(rectTransform);
            //rt.SetSiblingIndex(rectTransform.childCount - 1);
        }

    }
}

