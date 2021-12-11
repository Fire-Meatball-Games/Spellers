using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CustomEventSystem;

namespace Runtime
{
    public class PlayerEventManager : MonoBehaviour
    {
        private int total_hits;
        private int total_tries;
        private int total_fails;

        public PlayerEvent totalHitsEvent;
        public PlayerEvent totalFailsEvent;

        public int TotalHits { get => total_hits; set { total_hits = value; totalHitsEvent?.Invoke(value); } }
        public int TotalTries{ get => total_tries; set => total_tries = value; }
        public int TotalFails { get => total_fails; set { total_fails = value; totalFailsEvent?.Invoke(value); }  }


        private void OnEnable()
        {
            Events.OnPlayerUseSpell.AddListener(AddHit);
            Events.OnFailSpell.AddListener(AddFail);
        }

        private void OnDisable()
        {
            Events.OnPlayerUseSpell.RemoveListener(AddHit);
            Events.OnFailSpell.RemoveListener(AddFail);
            totalHitsEvent.Clear();
            totalFailsEvent.Clear();
        }

        private void AddHit()
        {
            TotalHits++;
            TotalTries++;
            Debug.Log("Acierto");
        }

        private void AddFail()
        {
            TotalFails++;
            TotalTries++;
            Debug.Log("Fallo");
        }


    }

}