using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SpellSystem;
using CustomEventSystem;

namespace Runtime.CombatSystem
{
    public class SpellerNPC : Speller
    {
        #region Private Fields
        private SpellerNPCSettings settings;
        private int id;
        #endregion

        #region Initialization

        public void SetSettings(SpellerNPCSettings settings)
        {
            this.settings = settings;
            spellerName = settings.spellerName;
            stats = new SpellSystem.SpellerStats();

            stats.OnChangeHealthEvent += (n) => Events.OnChangeEnemyHealth.Invoke(id, n);
            stats.OnChangeShieldsEvent += (n) => Events.OnChangeEnemyShields.Invoke(id, n);
            stats.OnChangeAttackEvent += (n) => Events.OnChangeEnemyAttack.Invoke(id, n);
            stats.OnDefeatEvent += () => Events.OnDefeatEnemy.Invoke(id);
            stats.OnDefeatEvent += () => DisableCombat();
            Events.OnBattleBegins.AddListener(Active);
        }

        public void Active()
        {
            LoadSpell();
        }

        public void SetTarget()
        {
            target = FindObjectOfType<SpellerPlayer>();
        }

        protected override void UseSpell(SpellUnit spellUnit)
        {
            base.UseSpell(spellUnit);
            LoadSpell();
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

        protected override SpellUnit GetActiveSpell()
        {
            return settings.deck.GetRandomSpell();
        }
    }
}
