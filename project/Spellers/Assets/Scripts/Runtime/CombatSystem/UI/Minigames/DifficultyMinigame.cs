using CustomEventSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Runtime.CombatSystem.UI
{
    public class DifficultyMinigame : Minigame
    {
        public RectTransform vessel_layout;
        public RectTransform vessel1, vessel2, vessel3;
        public RectTransform ball;

        public void Start()
        {
            vessel1.gameObject.GetComponent<Button>().onClick.AddListener(GenerateGame);
            vessel2.gameObject.GetComponent<Button>().onClick.AddListener(CompleteGame);
            vessel3.gameObject.GetComponent<Button>().onClick.AddListener(GenerateGame);
        }

        public override void CompleteGame()
        {
            Events.OnCompleteDifficultyMinigame.Invoke();
            ExitGame();
        }

        public override void GenerateGame()
        {
            vessel1.pivot = new Vector2(0f, 0.5f);
            vessel2.pivot = new Vector2(0.5f, 0.5f);
            vessel3.pivot = new Vector2(1f, 0.5f);
            ball.pivot = new Vector2(0.5f, 0.5f);
            vessel1.gameObject.GetComponent<Button>().interactable = false;
            vessel2.gameObject.GetComponent<Button>().interactable = false;
            vessel3.gameObject.GetComponent<Button>().interactable = false;
            StartCoroutine(Hideball());
        }

        private IEnumerator Hideball(int ticks = 30, float delay = 0.5f)
        {
            Vector2 min_0 = new Vector2(0.15f, 0.7f);
            Vector2 max_0 = new Vector2(0.85f, 0.85f);
            Vector2 min_1 = new Vector2(0.15f, 0.5f);
            Vector2 max_1 = new Vector2(0.85f, 0.65f);
            vessel_layout.anchorMin = min_0;
            vessel_layout.anchorMax = max_0;
            yield return new WaitForSeconds(delay);
            float delta = 1f / ticks; 
            for (int i = 0; i < ticks; i++)
            {
                float alpha = (i + 1) * delta;
                vessel_layout.anchorMin = Vector2.Lerp(min_0, min_1, alpha);
                vessel_layout.anchorMax = Vector2.Lerp(max_0, max_1, alpha);
                yield return new WaitForFixedUpdate();
            }
            yield return new WaitForSeconds(delay);
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
                if(tf1 == vessel2)
                    ball.pivot = Vector2.Lerp(init_1, init_2, alpha);
                if (tf2 == vessel2)
                    ball.pivot = Vector2.Lerp(init_2, init_1, alpha);
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
            else
            {
                yield return new WaitForSeconds(0.5f);
                vessel1.gameObject.GetComponent<Button>().interactable = true;
                vessel2.gameObject.GetComponent<Button>().interactable = true;
                vessel3.gameObject.GetComponent<Button>().interactable = true;
            }
        }

        private (RectTransform, RectTransform) GetTransformTouple()
        {
            int idx = Random.Range(0, 6);
            (RectTransform, RectTransform) douple;
            switch (idx)
            {
                case 0: douple = (vessel1, vessel2); break;
                case 1: douple = (vessel1, vessel3); break;
                case 2: douple = (vessel2, vessel1); break;
                case 3: douple = (vessel2, vessel3); break;
                case 4: douple = (vessel3, vessel1); break;
                default: douple = (vessel3, vessel2); break;
            }
            return douple;
        }  

    }

}