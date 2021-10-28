using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Runtime.CombatSystem
{
    public class Battle : MonoBehaviour
    {
        public enum Status
        {
            running,
            won,
            lost
        }

        public Status status;

        [SerializeField] private List<Speller> spellers;

        public delegate void OnChangeBattleDelegate();
        public event OnChangeBattleDelegate OnBeginBattle;
        public event OnChangeBattleDelegate OnEndBattle;

        public void Awake()
        {
            foreach (var speller in spellers)
            {
                if (speller is SpellerNPC)
                    speller.Stats.OnDefeatEvent += Win;
                if (speller is SpellerPlayer)
                    speller.Stats.OnDefeatEvent += Lose;
            }
        }

        public void Begin()
        {
            OnBeginBattle?.Invoke();
            foreach (var speller in spellers)
            {
                if (speller is SpellerNPC snpc)
                    snpc.Active();
            }
        }

        public void Win()
        {
            status = Status.won;
            OnEndBattle?.Invoke();
            foreach (var speller in spellers)
            {
                Destroy(speller.gameObject);
            }
        }

        public void Lose()
        {
            status = Status.lost;
            OnEndBattle?.Invoke();
            StopAllCoroutines();
            foreach (var speller in spellers)
            {
                Destroy(speller.gameObject);
            }
        }
    }

}