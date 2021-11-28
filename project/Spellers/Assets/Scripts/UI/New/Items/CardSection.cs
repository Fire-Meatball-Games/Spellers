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
        private List<SpellCardView> cards;

        public int num_cards => cards.Count;

        public void SetUp(string title, int maxItems = 0)
        {
            this.tittle = title;
            this.maxItems = maxItems;
            cards = new List<SpellCardView>(maxItems);
        }

        public void AddToLayout(SpellCardView card)
        {
            cards.Add(card);
            card.transform.SetParent(rectTransform);
            card.transform.localScale = Vector3.one;
        }

        public SpellCardView GetCardView(int idx)
        {
            if(idx >= 0 && idx < cards.Count)
            {
                return cards[idx];
            }
            else
            {
                return null;
            }
        }

        public void Clear()
        {
            for (int i = cards.Count - 1; i >= 0; i--)
            {
                SpellCardView card = cards[i];
                cards.RemoveAt(i);
                GameObject.Destroy(card.gameObject);
            }
            cards.Clear();
        }

    }
}

