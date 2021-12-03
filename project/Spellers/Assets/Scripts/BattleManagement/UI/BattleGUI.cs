using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CustomEventSystem;

namespace BattleManagement.UI
{
    public class BattleGUI : MonoBehaviour
    {
        // Start is called before the first frame update
        [SerializeField] private BattleManager battleManager;
        [SerializeField] private BattleSign battleSign;
        [SerializeField] private BattleCountDown countDown;

        public void SetUp()
        {
            Sprite playerIcon = battleManager.Player.Icon;
            Sprite enemyIcon = battleManager.Enemy.Icon;            
            battleSign.SetUp(playerIcon, enemyIcon);
            Debug.Log("Battle sign setted up");
        }

        private void Awake() 
        {           
            battleSign.OnPressStart += countDown.StartCountDown;
            countDown.OnEndCountDown += battleManager.StartBattle;
        }

        private void OnEnable() 
        {
            Events.OnBattleReady.AddListener(SetUp);
        }

        private void OnDisable() 
        {
            Events.OnBattleReady.RemoveListener(SetUp);
        }






    }

}
