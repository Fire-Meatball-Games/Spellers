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
            stats = new SpellerStats();

            stats.OnChangeHealthEvent += (n) => Events.OnChangeEnemyHealth.Invoke(id, n);
            stats.OnChangeShieldsEvent += (n) => Events.OnChangeEnemyShields.Invoke(id, n);
            stats.OnChangeAttackEvent += (n) => Events.OnChangeEnemyAttack.Invoke(id, n);
            stats.OnChangeDefenseEvent += (n) => Events.OnChangeEnemyDefense.Invoke(id, n);
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
            Spell spell = settings.deck.GetRandomSpell();
            spell = spell ?? Spell.DefaultSpell();
            int lvl = spell.power < 3 ? new System.Random().Next(1, 3) : 3;
            return new SpellUnit(spell, lvl);
        }
    }
}
