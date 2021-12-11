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
        private List<CardView> m_cards;

        public int num_cards => m_cards.Count;

        public void SetLayout(string title, List<CardView> cards)
        {
            title_txt.text = title;
            m_cards = new List<CardView>();
            foreach (var card in cards)
            {
                m_cards.Add(card);
                card.transform.SetParent(rectTransform);
                card.transform.localScale = Vector3.one;
            }
        }

        public void SetCardAt(CardView cardView, int index)
        {          
            if(index >= 0 && index < m_cards.Count)
            {
                CardView card = m_cards[index];
                m_cards.RemoveAt(index);
                GameObject.Destroy(card.gameObject);
                m_cards.Insert(index, cardView);
                cardView.transform.SetParent(rectTransform);
                cardView.transform.localScale = Vector3.one;
            }
        }

        public CardView GetCardView(int idx)
        {
            if(idx >= 0 && idx < m_cards.Count)
            {
                return m_cards[idx];
            }
            else
            {
                return null;
            }
        }

        public void Clear()
        {
            for (int i = m_cards.Count - 1; i >= 0; i--)
            {
                CardView card = m_cards[i];
                m_cards.RemoveAt(i);
                GameObject.Destroy(card.gameObject);
            }
            m_cards.Clear();
        }

    }
}

