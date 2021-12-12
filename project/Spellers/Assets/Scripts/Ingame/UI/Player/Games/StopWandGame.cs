using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Utils;

namespace Ingame.UI
{
    public class StopWandGame : GameBoard
    {
        [SerializeField] private GameObject stopWandPrefab;
        [SerializeField] private float threshold = 0.1f;
        [SerializeField] private int totalHits = 3;
        [SerializeField] private float speed = 1f;

        private GameObject stopWand;

        private Slider slider;
        private Button stopButton;
        private float value;
        private int counter;

        public override void Generate()
        {
            stopWand= Instantiate(stopWandPrefab, rectTransform);
            stopButton = stopWand.GetComponentInChildren<Button>();
            slider = stopWand.GetComponentInChildren<Slider>();

            stopButton.onClick.AddListener(Click);

            slider.value = 0.5f;
            value = 0.5f;
            speed = 1f;
            counter = 0;
            StartCoroutine(WandCoroutine());
        }



        private IEnumerator WandCoroutine()
        {
            float currentTime = 0f;
            while(true)
            {
                currentTime += Time.deltaTime * speed * (counter + 1);
                value = (Mathf.Cos(Mathf.PI * 0.5f * currentTime) + 1 ) * 0.5f;
                slider.value = value;
                yield return null;
            }
        }

        private void Click()
        {
            if(Mathf.Abs(value - 0.5f) < threshold)
            {
                counter++;
                if (counter == totalHits)
                {
                    Success();
                    Clear();
                }
                    
            }
            else
            {
                counter = 0;
            }
        }

        public override void Clear()
        {
            Destroy(stopWand);
        }
    }
}

