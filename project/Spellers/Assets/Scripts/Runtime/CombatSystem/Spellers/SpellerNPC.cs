using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SpellSystem;

namespace Runtime.CombatSystem
{
    public class SpellerNPC : Speller
    {
        [SerializeField] private List<Spell> spells_list;

        protected void LaunchSpell()
        {
            Spell s = spells_list[new System.Random().Next(spells_list.Count)];
            UseSpell(s);            
        }

        protected override void Init()
        {
            base.Init();
            target = FindObjectOfType<SpellerPlayer>();            
        }

        IEnumerator SpellCooldown(float time)
        {
            yield return new WaitForSeconds(time);
            LaunchSpell();
            StartNewCounter();
        }

        private void StartNewCounter()
        {
            IEnumerator corroutine = SpellCooldown(Random.Range(5, 15));
            StartCoroutine(corroutine);
        }

        public override void GetReady()
        {
            base.GetReady();
            StartNewCounter();
        }
    }
}
