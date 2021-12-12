using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Tweening;
using System;

namespace BattleManagement.UI
{
    public class BattleResults : MonoBehaviour
    {
        [SerializeField] private RectTransform layout;
        [SerializeField] private TextMeshProUGUI text_results;
        [SerializeField] private Sprite star_complete;
        [SerializeField] private Sprite star_hollow;
        [SerializeField] private List<Image> stars;
        [SerializeField] private TextMeshProUGUI text_details;
        [SerializeField] private Button exit_button;
        [SerializeField] private BattleEventStats eventStats;

        public event Action OnExitBattle = delegate{};
        
        private EffectBuilder showEffects;
        private void Awake() 
        {
            exit_button.onClick.AddListener(ExitBattle);
            showEffects = new EffectBuilder(this)
            .AddEffect(new ScreenSlideEffect(layout, Vector3.up * 1.2f, Vector3.zero,  1.1f, 0.2f))
            .AddEffect(new EnableEffect(layout.gameObject, 0f, true));

            foreach(var star in stars)
                star.sprite = star_hollow;
            
            text_details.text = "";
            exit_button.gameObject.SetActive(false);
            layout.gameObject.SetActive(false);
        }

        public void Show(bool win)
        {
            text_results.text =  win ? "¡Has ganado!" : "Has perdido";
            showEffects.ExecuteEffects();
            StartCoroutine(ShowResultsCoroutine());            
        }

        public IEnumerator ShowResultsCoroutine()
        {
            Debug.Log("EEE");
            yield return new WaitForSeconds(0.3f);
            
            var ts = TimeSpan.FromSeconds(eventStats.BattleTime);
            text_details.text += "Tiempo total : " + string.Format("{0:00}:{1:00}", ts.TotalMinutes, ts.Seconds) + "\n";
            yield return new WaitForSeconds(0.5f);
  
            text_details.text += "hechizos acertados: " + eventStats.SpellHits + "\n";
            yield return new WaitForSeconds(0.5f);

            text_details.text += "hechizos fallidos: " + eventStats.SpellFails + "\n";
            yield return new WaitForSeconds(0.5f);

            text_details.text += "\n";
            yield return new WaitForSeconds(0.5f);

            int score = Mathf.RoundToInt(600000f / (eventStats.BattleTime)) * eventStats.SpellHits / eventStats.SpellAttemps;

            string currentText = text_details.text;
            float currentTime = 0;
            while(currentTime < 2f)
            {
                currentTime += Time.deltaTime;
                int scoreDisplayed = (int) Mathf.Lerp(0, score, currentTime * 0.5f);
                text_details.text = currentText + "Puntuacion: " + scoreDisplayed;
                yield return null;
            }

            yield return new WaitForSeconds(0.5f);

            foreach(var star in stars)
            {
                star.sprite = star_complete;
                yield return new WaitForSeconds(0.3f);
            }                

            exit_button.gameObject.SetActive(true);
        }

        private void ExitBattle()
        {
            OnExitBattle?.Invoke();
        }
    } 

}
