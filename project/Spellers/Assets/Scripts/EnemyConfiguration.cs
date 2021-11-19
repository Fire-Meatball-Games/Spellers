using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using CustomEventSystem;
using SpellSystem;

namespace UIManagement
{
    public class EnemyConfiguration : MonoBehaviour
    {

        public enum Difficulty
        {
            Facil, 
            Normal,
            Dificil
        }

        // GUI:
        public GameObject layout_panel;
        public Button add_button;
        public Button remove_button;
        public Image icon;
        public TextMeshProUGUI enemyname;
        public Slider diff_slider;
        public Button r_button, l_button, random_button;

        // Fields:
        public Difficulty difficulty;
        public int index;


        private void OnEnable()
        {
            Events.OnChangeSpellerNPCSettings.AddListener(ChangeLayout);
        }

        private void OnDisable()
        {
            Events.OnChangeSpellerNPCSettings.RemoveListener(ChangeLayout);
        }


        private void ChangeLayout(int idx, SpellerNPCSettings settings)
        {
            if (index != idx) return;

            enemyname.text = settings.spellerName;
            icon.sprite = settings.icon;

        }
    } 
}
