using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

namespace BattleManagement.UI
{
    public class BattleCountDown : MonoBehaviour
    {
        [SerializeField] private GameObject layout;
        [SerializeField] private TextMeshProUGUI CoundDown_txt;

        public event Action OnEndCountDown = delegate{}; 

        public void StartCountDown()
        {
            layout.SetActive(true);
            StartCoroutine(CountDown());
        }

        private IEnumerator CountDown()
        {
            var time = 0f;
            CoundDown_txt.text = "" + 3;

            while(time < 1f)
            {
                time += Time.deltaTime;
                CoundDown_txt.transform.localScale = Vector3.one * (1f + time / 2); 
                yield return null;                
            }
            time = 0f;
            CoundDown_txt.transform.localScale = Vector3.one;
            CoundDown_txt.text = "" + 2;

            while(time < 1f)
            {
                time += Time.deltaTime;
                CoundDown_txt.transform.localScale = Vector3.one * (1f + time / 2);  
                yield return null;              
            }

            time = 0f;
            CoundDown_txt.transform.localScale = Vector3.one;
            CoundDown_txt.text = "" + 1;

            while(time < 1f)
            {
                time += Time.deltaTime;
                CoundDown_txt.transform.localScale = Vector3.one * (1f + time / 2);  
                yield return null;               
            }

            time = 0f;
            CoundDown_txt.transform.localScale = Vector3.one;
            CoundDown_txt.text = "Spell!";

            while(time < 1f)
            {
                time += Time.deltaTime;
                CoundDown_txt.transform.localScale = Vector3.one * (1f + time / 2);    
                yield return null;             
            }

            OnEndCountDown?.Invoke();
            layout.SetActive(false);
        }
    }

}
