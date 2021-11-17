using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

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
        public TMP_Dropdown DD_difficulty;


        // Fields:
        Difficulty difficulty;

        // Start is called before the first frame update
        void Start()
        {
            DD_difficulty.ClearOptions();
            List<string> dif_options = new List<string>(Enum.GetNames(typeof(Difficulty)));
            DD_difficulty.AddOptions(dif_options);
            DD_difficulty.value = (int)Difficulty.Normal;
            DD_difficulty.onValueChanged.AddListener(OnChangeDifficultyDropDown);
        }


        private void OnChangeDifficultyDropDown(int n)
        {
            difficulty = (Difficulty)n;
            Debug.Log("Change dif to " + difficulty);
        }
    } 
}
