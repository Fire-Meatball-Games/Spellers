using CustomEventSystem;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace Runtime.CombatSystem.UI
{
    public class BlindMinigame : Minigame
    {
        public GameObject card_prefab;
        private List<Card> cards;
        private int lastCardIdx;
        private int hits;

        public override void CompleteGame()
        {
            Events.OnCompleteBlindMinigame.Invoke();
            ExitGame();
        }

        private void Start()
        {
            cards = new List<Card>();
            for (int i = 0; i < 8; i++)
            {
                Card card = Instantiate(card_prefab, game_area).GetComponent<Card>();
                card.SetId((i / 2) + 1);
                cards.Add(card);
                card.FlipCardEvent += CheckCard;
            }
        }

        public override void GenerateGame()
        {
            hits = 0;
            cards = cards.OrderBy(x => Random.value).ToList();

            for (int i = 0; i < cards.Count; i++)
            {
                cards[i].gameObject.SetActive(true);
                cards[i].active = true;
                if (cards[i].flipped)
                    cards[i].Flip();
                int row = i / 4;
                int col = i % 4;
                var rt = cards[i].gameObject.GetComponent<RectTransform>();
                rt.anchorMin = new Vector2(col * 0.25f, 0.5f - 0.3f * row);
                rt.anchorMax = rt.anchorMin + new Vector2(0.25f, 0.3f);
            }
        }

        private void CheckCard(int id)
        {
            if(lastCardIdx == 0)
            {
                lastCardIdx = id;
            }
            else
            {
                if(lastCardIdx == id)
                {
                    foreach (var card in cards)
                    {
                        if (card.GetId() == lastCardIdx)
                        {
                            card.active = false;
                            card.Disable();
                        }
                            
                    }
                    hits++; 
                    if(hits == 4)
                    {
                        CompleteGame();
                    }
                        
                }
                else
                {
                    foreach (var card in cards)
                    {
                        if (card.flipped && card.active)
                            card.FlipCard();
                    }
                }
                lastCardIdx = 0;
            }
        }
    }

}
