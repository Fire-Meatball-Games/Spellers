using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CustomEventSystem;
using Levels;

namespace BattleManagement
{
    public class BattleEventStats : MonoBehaviour
    {
        [SerializeField] private float battleTime;
        [SerializeField] private int spellHits;
        [SerializeField] private int spellFails;
        [SerializeField] private int spellAttemps;

        [SerializeField] private PlayerEvent spellHitsEvent;
        [SerializeField] private PlayerEvent spellFailsEvent;

        public float BattleTime => battleTime;
        public int SpellHits { get => spellHits; set { spellHits = value; spellHitsEvent?.Invoke(value); } }
        public int SpellFails { get => spellFails; set { spellFails = value; spellFailsEvent?.Invoke(value); }  }
        public int SpellAttemps{ get => spellAttemps; set => spellAttemps = value; }
        

        private void OnEnable() 
        {
            Events.OnPlayerUseSpell.AddListener(AddHit);
            Events.OnFailSpell.AddListener(AddFail);
        }

        private void OnDisable()
        {
            Events.OnPlayerUseSpell.RemoveListener(AddHit);
            Events.OnFailSpell.RemoveListener(AddFail);
        }

        public void StartTimer() => StartCoroutine(BattleTimer());

        private IEnumerator BattleTimer()
        {
            battleTime = 0f;
            while(true)
            {
                battleTime += Time.deltaTime;
                yield return null;
            }
        }

        private void AddHit()
        {
            SpellHits++;
            SpellAttemps++;
            Debug.Log("Acierto");
        }

        private void AddFail()
        {
            spellFails++;
            SpellAttemps++;
            Debug.Log("Fallo");
        }


    }
}

