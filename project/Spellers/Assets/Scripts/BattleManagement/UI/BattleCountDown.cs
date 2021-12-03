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
            CoundDown_txt.text = "" + 3;
            yield return new WaitForSeconds(1f);
            CoundDown_txt.text = "" + 2;
            yield return new WaitForSeconds(1f);
            CoundDown_txt.text = "" + 1;
            yield return new WaitForSeconds(1f);
            CoundDown_txt.text = "Spell!";
            yield return new WaitForSeconds(1f);

            OnEndCountDown?.Invoke();
            layout.SetActive(false);
        }
    }

}
