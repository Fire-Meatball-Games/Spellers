using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SpellSystem;

namespace Runtime.CombatSystem
{
    public class SpellerNPC : Speller
    {
        #region Private Fields
        private SpellerNPCSettings settings;
        #endregion

        #region Initialization
        public override void Init()
        {
            base.Init();
            target = FindObjectOfType<SpellerPlayer>();
            OnUseSpellEvent += LoadSpell;
            stats.OnDefeatEvent += DisableCombat;
        }

        public void SetSettings(SpellerNPCSettings npc_settings)
        {
            settings = npc_settings;
            spellerName = npc_settings.spellerName;
        }

        public void Active()
        {
            LoadSpell();
        }

        public void SetTarget()
        {
            target = FindObjectOfType<SpellerPlayer>();
        }

        #endregion


        private void DisableCombat()
        {
            StopAllCoroutines();
        }

        IEnumerator LoadSpellCorroutine(float time)
        {
            yield return new WaitForSeconds(time);
            LaunchSpell();
        }

        private void LoadSpell()
        {
            float min_cd = settings.cooldown_average - settings.cooldown_deviation;
            float max_cd = settings.cooldown_average + settings.cooldown_deviation;
            IEnumerator corroutine = LoadSpellCorroutine(Random.Range(min_cd, max_cd));
            StartCoroutine(corroutine);
        }

        protected override Spell GetActiveSpell()
        {
            Spell spell = settings.deck.GetRandomSpell();
            return spell ?? Spell.DefaultSpell();
        }

        
    }
}
