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
        [SerializeField] private EnemyController controller;
        
        #endregion

        #region Initialization

        public void SetUp(EnemyController controller)
        {
            this.controller = controller;           
        }

        public override void Active()
        {
            LoadSpell();
        } 

        public void Disable()
        {
            StopAllCoroutines();
            this.spellWand.StopAllCoroutines();
        } 

        public override void OnUseSpell()
        {
            base.OnUseSpell();
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
            int cd_level = Mathf.Clamp(Stats.OrderState.CurrentValue + Stats.TimeState.CurrentValue, -3, 3);
            IEnumerator corroutine = LoadSpellCorroutine(time * (1f - cd_level / 10f));
            StartCoroutine(corroutine);
        }

        protected override SpellSystem.SpellUnit GetActiveSpell()
        {
            return controller.deck.GetRandomSpell(controller.max_spell_lvl);
        }
    }
}
