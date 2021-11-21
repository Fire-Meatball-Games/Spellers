using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SpellSystem;
using CustomEventSystem;
using Runtime;

namespace Runtime.CombatSystem
{
    public class SpellerNPC : Speller
    {
        #region Private Fields
        private SpellerNPCSettings settings;
        private readonly int id;
        #endregion

        #region Initialization
        private void OnEnable()
        {
            Events.OnBattleBegins.AddListener(Active);
        }

        private void OnDisable()
        {
            Events.OnBattleBegins.RemoveListener(Active);
        }

        public void SetSettings(SpellerNPCSettings settings)
        {
            spellWand = FindObjectOfType<SpellWand>();
            this.settings = settings;
            spellerName = settings.spellerName;
            stats = new SpellSystem.SpellerStats();

            stats.OnChangeHealthEvent += (n) => Events.OnChangeEnemyHealth.Invoke(id, n);
            stats.OnChangeShieldsEvent += (n) => Events.OnChangeEnemyShields.Invoke(id, n);

            stats.OnChangeAttackEvent += (n) => Events.OnChangeEnemyAttack.Invoke(id, n);
            stats.OnChangeRegenerationEvent += (n) => Events.OnChangeEnemyRegeneration.Invoke(id, n);
            stats.OnChangeSlotLevelsEvent += (n) => Events.OnChangeEnemySlots.Invoke(id, n);
            stats.OnChangeOrderEvent += (n) => Events.OnChangeEnemyOrder.Invoke(id, n);

            stats.OnDefeatEvent += () => Events.OnDefeatEnemy.Invoke(id);
            stats.OnDefeatEvent += () => DisableCombat();
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
            float time = Random.Range(min_cd, max_cd);
            int cd_level = Mathf.Clamp(stats.Order + stats.Difficulty, -3, 3);
            IEnumerator corroutine = LoadSpellCorroutine(time * (1f - 3f/cd_level));
            StartCoroutine(corroutine);
        }

        protected override SpellUnit GetActiveSpell()
        {
            return settings.deck.GetRandomSpellWithlvlMax(settings.max_spell_lvl);
        }
    }
}
