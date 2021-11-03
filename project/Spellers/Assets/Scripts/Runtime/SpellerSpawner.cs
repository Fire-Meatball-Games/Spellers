using Runtime.CombatSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Runtime
{
    public class SpellerSpawner : MonoBehaviour
    {
        public GameObject npc_prefab;
        public GameObject player_prefab;
        public Battle battle;

        public Transform player_spawn_point, enemy_spawn_point;

        // Start is called before the first frame update
        void Start()
        {
            Init();
        }

        private void Init()
        {
            SpellerPlayer player = GeneratePlayer();
            battle.SetPlayer(player);
            foreach (var npc_settings in GameController.instance.settings.speller_Settings)
            {
                GameObject speller_go = Instantiate(npc_prefab, enemy_spawn_point);
                SpellerNPC speller = speller_go.GetComponent<SpellerNPC>();
                speller.SetSettings(npc_settings);
                speller.SetTarget(player);
                battle.AddEnemy(speller);
            }
            player.SetTarget(battle.enemies[0]);
        }

        // Crea al jugador en la escena
        private SpellerPlayer GeneratePlayer()
        {
            var player_obj = Instantiate(player_prefab, player_spawn_point);
            SpellerPlayer player = player_obj.GetComponent<SpellerPlayer>();
            return player;
        }
    }

}