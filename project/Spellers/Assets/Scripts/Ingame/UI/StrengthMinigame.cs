using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using CustomEventSystem;

namespace Ingame.UI
{
    public class StrengthMinigame : Minigame
    {
        public Slider slider;
        public Button stop_btn;
        const float threshold = 0.1f;

        private int hits;
        private float value;
        

        public override void CompleteGame()
        {
            Events.OnCompleteStrengthMinigame.Invoke();
            ExitGame();
        }

        public void Start()
        {
            stop_btn.onClick.AddListener(Click);
        }

        public override void GenerateGame()
        {
            hits = 0;
            StartCoroutine(SliderCoroutine(true));
        }


        private IEnumerator SliderCoroutine(bool dir)
        {            
            while (true)
            {
                int ticks = 100 - 30 * hits;
                float delta = 1f / ticks;
                for (int i = 0; i < ticks; i++)
                {
                    slider.value = dir ? (i + 1) * delta : 1 - (i + 1) * delta;
                    value = slider.value;
                    yield return new WaitForFixedUpdate();
                }
                dir = !dir;
            }            
        }

        private void Click()
        {
            if(Mathf.Abs(value - 0.5f) < threshold)
            {
                hits++;
                Debug.Log(hits);
                if (hits == 3)
                    CompleteGame();
            }
            else
            {
                hits = 0;
                Debug.Log("fail");
            }
        }
    }
}
