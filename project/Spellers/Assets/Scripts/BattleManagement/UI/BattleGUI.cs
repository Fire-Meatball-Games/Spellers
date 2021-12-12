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

        [SerializeField] private BattlePause pause;
        [SerializeField] private BattleResults results;

        public void SetUp()
        {
            Sprite playerIcon = battleManager.player.Icon;
            Sprite enemyIcon = battleManager.enemy.Icon;            
            battleSign.SetUp(playerIcon, enemyIcon);
        }

        private void Awake() 
        {        
            battleManager.OnBattleEnds += ShowResults;
            battleSign.OnPressStart += countDown.StartCountDown;
            countDown.OnEndCountDown += battleManager.StartBattle;
            results.OnExitBattle += battleManager.ExitBattle; 
            pause.OnExitBattle += battleManager.ExitBattle;        
        }

        private void OnEnable() 
        {
            Events.OnBattleReady.AddListener(SetUp);
        }

        private void OnDisable() 
        {
            Events.OnBattleReady.RemoveListener(SetUp);
        }

        private void ShowResults(bool win) => results.Show(win);



    }

}
