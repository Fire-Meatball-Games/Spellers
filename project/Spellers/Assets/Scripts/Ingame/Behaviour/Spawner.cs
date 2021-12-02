using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ingame
{
    public class Spawner : MonoBehaviour
    {
        #region Inspector Fields
        [SerializeField] private GameObject player_prefab;
        [SerializeField] private GameObject enemy_prefab;        
        [SerializeField] private Transform player_spawn_point;
        [SerializeField] private Transform enemy_spawn_point;

        #endregion

        #region Private fields
        private GameObject player;
        private GameObject enemy;

        #endregion

        #region Private Methods  

        // Genera al enemigo en la escena
        public SpellerNPC GenerateEnemy()
        {
            enemy = Instantiate(enemy_prefab,  enemy_spawn_point);
            return enemy.GetComponent<SpellerNPC>();
        } 

        // Crea al jugador en la escena
        public SpellerPlayer GeneratePlayer()
        {
            var player = Instantiate(player_prefab, player_spawn_point);
            return player.GetComponent<SpellerPlayer>();
        }

        // Elimina al enemigo de la escena
        public void DestroyEnemy()
        {
            Destroy(enemy);
            enemy = null;
        }

        // Elimian al jugador de la escena
        public void DestroyPlayer()
        {
            Destroy(player);
            player = null;
        }
        #endregion
    }

}
