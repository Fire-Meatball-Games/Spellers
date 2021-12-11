using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Ingame.UI
{
    public class Card : MonoBehaviour
    {
        public GameObject front;
        public GameObject back;
        public Button flip_button;
        public TextMeshProUGUI text;

        public delegate void FlipCardDelegate(int id);
        public event FlipCardDelegate FlipCardEvent;

        private int id;

        public bool flipped;
        public bool active;
        public int flip_ticks = 2000;

        private bool isFlipping;

        public void FlipCard()
        {
            StartCoroutine(FlipCorroutine());
        }

        private void Awake()
        {
            active = true;
            flip_button.onClick.AddListener(() => {
                if (!isFlipping)
                {
                    FlipCard();                    
                }
            });
        }

        public void SetId(int id)
        {
            this.id = id;
            text.text = ""+ id;
        }

        public int GetId()
        {
            return id;
        }

        public void Disable()
        {
            active = false;
            gameObject.SetActive(false);            
        }

        private IEnumerator FlipCorroutine()
        {
            isFlipping = true;
            float delta = 2f / flip_ticks;
            for (int i = 0; i < flip_ticks / 2; i++)
            {
                transform.localScale = new Vector3((1f - (i + 1) * delta), 1f, 1f);
                yield return new WaitForFixedUpdate();
            }
            Flip();
            for (int i = 0; i < flip_ticks / 2; i++)
            {
                transform.localScale = new Vector3((i + 1) * delta, 1f, 1f);
                yield return new WaitForFixedUpdate();
            }
            isFlipping = false;            

            if(flipped)
                FlipCardEvent.Invoke(id);
        }

        public void Flip()
        {
            flipped = !flipped;
            front.SetActive(flipped);
            back.SetActive(!flipped);
        }
    } 
}
