using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace Ingame.UI
{
    public class PotionGame : GameBoard
    {
        [SerializeField] private GameObject potion_real_prefab;
        [SerializeField] private GameObject potion_fake_prefab;
        [SerializeField] private int dimension = 4;
        [SerializeField] private int total_hits = 6;
        private GameObject[] potions;
        private int hits;

        public override void Clear()
        {
            if(potions == null) return;
            for (int i = 0; i < potions.Length; i++)
            {
                if (potions[i] != null)
                    Destroy(potions[i]);
            }
            potions = null;
        }

        public override void Generate()
        {
            potions = new GameObject[dimension*dimension];
            hits = 0;
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
                    potions[idx] = Instantiate(potion_real_prefab, rectTransform);
                    potions[idx].GetComponent<Button>().onClick.AddListener(() => Destroy(potions[idx]));
                    potions[idx].GetComponent<Button>().onClick.AddListener(ClickRealPotion);
                    
                }
                else
                {
                    potions[idx] = Instantiate(potion_fake_prefab, rectTransform);
                    potions[idx].GetComponent<Button>().onClick.AddListener(() => Destroy(potions[idx]));
                    potions[idx].GetComponent<Button>().onClick.AddListener(ClickFakePotion);                    
                }
            }   

            float size = 1.0f / dimension;

            for (int i = 0; i < dimension; i++)
            {
                for (int j = 0; j < dimension; j++)
                {
                    var rt = potions[j + i * dimension].GetComponent<RectTransform>();
                    rt.anchorMin = new Vector2(i * size, j * size);
                    rt.anchorMax = new Vector2((i + 1) * size, (j + 1) * size);
                }
            }   
        }

        private void ClickFakePotion()
        {
            Clear();
            Generate();
        }

        private void ClickRealPotion()
        {
            hits++;
            if (hits == total_hits)
            {
                Success();
                Clear();
            }
        }
    }

}
