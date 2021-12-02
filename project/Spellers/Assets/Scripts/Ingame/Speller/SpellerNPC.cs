using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SpellSystem;
using CustomEventSystem;

namespace Ingame
{
    public class SpellerNPC : Speller
    {
        #region Private Fields
        private SpellerNPCSettings settings;
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

            Stats.OnChangeHealthEvent += (n) => Events.OnChangeEnemyHealth.Invoke(n);
            Stats.OnChangeShieldsEvent += (n) => Events.OnChangeEnemyShields.Invoke(n);

            Stats.OnChangeAttackEvent += (n) => Events.OnChangeEnemyAttack.Invoke(n);
            Stats.OnChangeRegenerationEvent += (n) => Events.OnChangeEnemyRegeneration.Invoke( n);
            Stats.OnChangeSlotLevelsEvent += (n) => Events.OnChangeEnemySlots.Invoke(n);
            Stats.OnChangeOrderEvent += (n) => Events.OnChangeEnemyOrder.Invoke(n);

            Stats.OnDefeatEvent += () => Events.OnDefeatEnemy.Invoke();
            Stats.OnDefeatEvent += () => DisableCombat();
        }

        public void Active()
        {
            LoadSpell();
        }

        protected override void UseSpell(SpellSystem.SpellUnit spellUnit)
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
            int cd_level = Mathf.Clamp(Stats.Order + Stats.Difficulty, -3, 3);
            IEnumerator corroutine = LoadSpellCorroutine(time * (1f - cd_level / 10f));
            StartCoroutine(corroutine);
        }

        protected override SpellSystem.SpellUnit GetActiveSpell()
        {
            return settings.deck.GetRandomSpell(settings.max_spell_lvl);
        }

        public override void SetUp()
        {
            throw new System.NotImplementedException();
        }
    }
}
