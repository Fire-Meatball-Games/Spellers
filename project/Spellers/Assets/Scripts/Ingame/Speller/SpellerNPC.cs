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
        private EnemyController controller;
        
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

        public void SetUp(EnemyController controller)
        {
            this.controller = controller;           
        }

        public override void Active()
        {
            LoadSpell();
        }

        protected override void UseSpell(SpellSystem.SpellUnit spellUnit)
        {
            base.UseSpell(spellUnit);
            LoadSpell();
        }
        #endregion

        IEnumerator LoadSpellCorroutine(float time)
        {
            yield return new WaitForSeconds(time);
            LaunchSpell();
        }

        private void LoadSpell()
        {
            float min_cd = controller.cooldown_average - controller.cooldown_deviation;
            float max_cd = controller.cooldown_average + controller.cooldown_deviation;
            float time = Random.Range(min_cd, max_cd);
            int cd_level = Mathf.Clamp(Stats.Order + Stats.Difficulty, -3, 3);
            IEnumerator corroutine = LoadSpellCorroutine(time * (1f - cd_level / 10f));
            StartCoroutine(corroutine);
        }

        protected override SpellSystem.SpellUnit GetActiveSpell()
        {
            return controller.deck.GetRandomSpell(controller.max_spell_lvl);
        }
    }
}
