using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SpellSystem;

namespace Runtime.CombatSystem
{
    public class SpellerNPC : Speller
    {
        [SerializeField] private List<Spell> spells_list;
        public float average_load_time = 10.0f;
        public float deviation_load_time = 5.0f;

        public override void Init()
        {
            base.Init();
            target = FindObjectOfType<SpellerPlayer>();
            OnUseSpellEvent += LoadSpell;
        }

        IEnumerator LoadSpellCorroutine(float time)
        {
            yield return new WaitForSeconds(time);
            LaunchSpell();
        }

        private void LoadSpell()
        {
            IEnumerator corroutine = LoadSpellCorroutine(Random.Range(average_load_time - deviation_load_time, average_load_time + deviation_load_time));
            StartCoroutine(corroutine);
        }

        protected override Spell GetActiveSpell()
        {
            return spells_list[new System.Random().Next(spells_list.Count)];
        }

        public void Active()
        {
            LoadSpell();
        }
    }
}
