using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SpellSystem;
using System;
using CustomEventSystem;

namespace Ingame
{
    // Componente que permite lanzar hechizos a los personajes:
    public class SpellWand : MonoBehaviour
    {
        public static readonly float LAUNCHTIME = 1f;

        [SerializeField] private GameObject spell_prefab;
        
        private Speller user;
        private Speller target;
        
        #region Public methods

        // Inicializacion:
        public void SetUp(Speller user, Speller target)
        {
            this.user = user;
            this.target = target;
        }

        // Lanzar hechizo:
        public void LaunchSpell(SpellUnit unit)
        {
            StartCoroutine(LaunchSpellCoroutine(unit));
        }

        #endregion

        private IEnumerator LaunchSpellCoroutine(SpellUnit unit)
        {
            Debug.Log("Spellwand: Using spell" + unit.ToString());
            Spell spell = unit.spell;
            Vector3 initPos = user.transform.position + Vector3.up + Vector3.back;
            Vector3 finalPos = target.transform.position + Vector3.up + Vector3.back;
            switch (spell.animationType)
            {
                case Spell.AnimationType.proyectile:
                    break;
                case Spell.AnimationType.target:
                    initPos = finalPos;
                    break;
                case Spell.AnimationType.self:
                    finalPos = initPos;
                    break;
            }
            
            var current_time = 0f;
            var delta = 1f / LAUNCHTIME;                
            var spellShot = Instantiate(unit.spell.Animation);
            var renderer = spellShot.GetComponent<SpriteRenderer>();
            var tf = spellShot.transform;
            tf.localScale = Vector3.one * 0.3f;
            renderer.flipX = user.transform.position.x > target.transform.position.x;
            tf.position = initPos;

            while(current_time < 0.4f)
            {
                current_time += Time.deltaTime;
                var t = delta * current_time;
                tf.position = Vector3.Lerp(initPos, finalPos, t);
                yield return null;
            }
            Destroy(spellShot);

            user.OnUseSpell();
            ApplySpell(unit);            
        }


        // Aplica los efectos correspondientes del hechizo lanzado
        public void ApplySpell(SpellUnit unit)
        {
            int level = unit.lvl;
            Spell spell = unit.spell;
            foreach(Effect effect in spell.effects)
            {
                effect.Apply(user.Stats, target.Stats, level);
            }
        }     
    } 
}
