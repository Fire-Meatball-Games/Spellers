using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using CustomEventSystem;

namespace Runtime.CombatSystem
{
    namespace UI
    {
        public class SpellerGUI : MonoBehaviour
        {
            #region GUI Elements
            public int index;
            public TextMeshProUGUI txt_name;
            public Slider healthSlider;
            public Slider shieldSlider;
            #endregion

            #region Set up
            public void SetUpPlayer(string playerName)
            {
                txt_name.text = playerName;
                Events.OnChangePlayerHealth.AddListener(SetHealthBar);
            }


            public void SetUpEnemy(int idx, string enemyName)
            {
                index = idx;
                txt_name.text = enemyName;
                Events.OnChangeEnemyHealth.AddListener(SetHealthBar);                    
            }

            #endregion

            #region Private Methods
            private void SetHealthBar(int health)
            {
                healthSlider.value = health;
            }
            private void SetHealthBar(int idx, int health)
            {
                if(idx == index)
                    healthSlider.value = health;               
            }

            private void SetAtkLvl(int lvl)
            {
                //
            }

            private void SetDefLvl(int lvl)
            {
                //
            }

            #endregion
        }

    }

}