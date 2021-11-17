using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Runtime.CombatSystem.UI
{
    public class DifficultyMinigame : Minigame
    {
        public RectTransform red_ball, green_ball, blue_ball;

        public override void CompleteGame()
        {
            
        }

        public override void GenerateGame()
        {
            int t = Random.Range(10, 40);
            (RectTransform, RectTransform) tp = GetTransformTouple();
            StartCoroutine(SwapSpheresCoroutine(tp.Item1, tp.Item2, t, 6));
        }


        private IEnumerator SwapSpheresCoroutine(RectTransform tf1, RectTransform tf2, int ticks, int counter)
        {
            Vector2 init_1 = tf1.pivot;
            Vector2 init_2 = tf2.pivot;
            float delta = 1f / ticks;

            for (int i = 0; i < ticks; i++)
            {
                float alpha = (i + 1) * delta;
                tf1.pivot = Vector2.Lerp(init_1, init_2, alpha);
                tf2.pivot = Vector2.Lerp(init_2, init_1, alpha);
                yield return new WaitForFixedUpdate();
            }
            counter--;
            if(counter > 0)
            {
                int t = Random.Range(10, 40);
                (RectTransform, RectTransform) tp = GetTransformTouple();
               StartCoroutine(SwapSpheresCoroutine(tp.Item1, tp.Item2, t, counter));
            }
        }

        private (RectTransform, RectTransform) GetTransformTouple()
        {
            int idx = Random.Range(0, 6);
            (RectTransform, RectTransform) douple;
            switch (idx)
            {
                case 0: douple = (red_ball, green_ball); break;
                case 1: douple = (red_ball, blue_ball); break;
                case 2: douple = (green_ball, red_ball); break;
                case 3: douple = (green_ball, blue_ball); break;
                case 4: douple = (blue_ball, red_ball); break;
                default: douple = (blue_ball, green_ball); break;
            }
            return douple;
        }  

    }

}