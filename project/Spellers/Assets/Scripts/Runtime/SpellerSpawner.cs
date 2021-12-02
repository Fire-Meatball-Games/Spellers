using Runtime.CombatSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SpellSystem;

namespace Runtime
{
    public class SpellerSpawner : MonoBehaviour
    {
        #region Public variables
        [SerializeField] private GameObject player_prefab;
        [SerializeField] private GameObject enemy_prefab;        
        [SerializeField] private Transform player_spawn_point;
        [SerializeField] private Transform enemy_spawn_point;

        #endregion

        #region Private Methods
  

        // Genera al enemigo en la escena
        public SpellerNPC GenerateEnemy()
        {
            var enemy_obj = Instantiate(enemy_prefab,  enemy_spawn_point);
            return enemy_obj.GetComponent<SpellerNPC>();
        } 


        // Crea al jugador en la escena
        public SpellerPlayer GeneratePlayer()
        {
            var player_obj = Instantiate(player_prefab, player_spawn_point);
            return player_obj.GetComponent<SpellerPlayer>();
        }
        #endregion
    }
}