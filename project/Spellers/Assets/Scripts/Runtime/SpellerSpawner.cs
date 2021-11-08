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
        public GameObject player_prefab;
        public GameObject npc_prefab;        
        public Transform player_spawn_point;
        public List<Transform> enemy_spawn_points;
        #endregion

        #region UnityCallbacks
        public void Start()
        {
            Init();
        }
        #endregion

        #region Private Methods
        // Genera los jugadores y enemigos de la escena
        private void Init()
        {
            SpellerBattle battle = FindObjectOfType<SpellerBattle>();
            List<SpellerNPCSettings> enemy_settings = GameController.instance.game_settings.speller_Settings;

            if (enemy_settings?.Count == 0)
            {
                throw new System.Exception("Error en la configuración de la partida: No hay enemigos");
            }

            SpellerPlayer player = GeneratePlayer();
            battle.AddPlayer(player);
            int num_enemies = Mathf.Min(enemy_settings.Count, enemy_spawn_points.Count);
            for (int i = 0; i < num_enemies; i++)
            {
                SpellerNPC speller = InstantiateEnemy(enemy_spawn_points[i]);
                speller.SetSettings(enemy_settings[i]);
                speller.SetTarget();
                battle.AddEnemy(speller, i);
            }
            
            player.SetTarget(battle.enemies[0], 0);
        }

        // Genera un enemigo en la escena
        private SpellerNPC InstantiateEnemy(Transform tf)
        {
            Vector3 spawn_position = tf.position;
            Quaternion spawn_rotation = tf.rotation;
            var speller_go = Instantiate(npc_prefab, spawn_position, spawn_rotation, transform);
            return speller_go.GetComponent<SpellerNPC>();
        } 


        // Crea al jugador en la escena
        private SpellerPlayer GeneratePlayer()
        {
            var player_obj = Instantiate(player_prefab, player_spawn_point);
            return player_obj.GetComponent<SpellerPlayer>();
        }
        #endregion
    }
}