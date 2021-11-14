using CustomEventSystem;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace Runtime.CombatSystem.UI
{
    public class RegenerationMinigame : Minigame
    {
        const int total_hits = 8;
        const int DIM = 4;
        private Vector2 spacing = new Vector2(0.05f, 0.05f);
        private int hits;

        private GameObject[] potions = new GameObject[DIM*DIM];

        public GameObject potion_real_prefab;
        public GameObject potion_fake_prefab;

        public override void GenerateGame()
        {
            hits = 0;
            CleanGameArea();
            bool[] mask = new bool[potions.Length];
            for (int i = 0; i < total_hits; i++)
            {
                mask[i] = true;
            }
            mask = mask.OrderBy(x => Random.value).ToArray();

            for (int i = 0; i < mask.Length; i++)
            {
                int idx = i;
                if (mask[idx])
                {
                    potions[idx] = Instantiate(potion_real_prefab, game_area);
                    potions[idx].GetComponent<Button>().onClick.AddListener(() => Destroy(potions[idx]));
                    potions[idx].GetComponent<Button>().onClick.AddListener(ClickRealPotion);
                    
                }
                else
                {
                    potions[idx] = Instantiate(potion_fake_prefab, game_area);
                    potions[idx].GetComponent<Button>().onClick.AddListener(() => Destroy(potions[idx]));
                    potions[idx].GetComponent<Button>().onClick.AddListener(ClickFakePotion);
                    
                }
            }            

            float size = 1.0f / DIM;

            for (int i = 0; i < DIM; i++)
            {
                for (int j = 0; j < DIM; j++)
                {
                    var rt = potions[j + i * DIM].GetComponent<RectTransform>();
                    rt.anchorMin = new Vector2(i * size, j * size);
                    rt.anchorMax = new Vector2((i + 1) * size, (j + 1) * size);
                }
            }
            panel.SetActive(true);
        }

        public override void CompleteGame()
        {
            Events.OnCompletePoisonMinigame.Invoke();
            ExitGame();
        }

        private void CleanGameArea()
        {
            for (int i = 0; i < potions.Length; i++)
            {
                if (potions[i] != null)
                    Destroy(potions[i]);
            }
        }


        private void ClickFakePotion()
        {
            GenerateGame();
        }

        private void ClickRealPotion()
        {
            hits++;
            if (hits == total_hits)
            {
                CompleteGame();
            }


        }

    }
}
