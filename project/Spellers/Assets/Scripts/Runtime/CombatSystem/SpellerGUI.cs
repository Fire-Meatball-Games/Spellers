using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Runtime.CombatSystem
{
    [RequireComponent(typeof(Speller))]
    public class SpellerGUI : MonoBehaviour
    {
        public Text txt_name;
        public Text txt_health;

        public Speller speller;
        public SpellerStats stats;

        void Start()
        {
            speller = GetComponent<Speller>();
            stats = speller.Stats;
            stats.OnChangeHealth += (int value) => ChangeHealthText(value.ToString());
        }

        private void ChangeHealthText(string message)
        {
            txt_health.text = "HP: " + message;
        }
    }

}