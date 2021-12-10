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
            if(spell.offensive)
            {
                Debug.Log("E");
                var current_time = 0f;
                var delta = 1f / LAUNCHTIME;                
                var spellShot = Instantiate(spell_prefab);
                var renderer = spellShot.GetComponent<SpriteRenderer>();
                var tf = spellShot.transform;
                renderer.sprite = spell.Sprite;
                renderer.flipX = user.transform.position.x < target.transform.position.x;
                tf.position = user.transform.position;

                while(tf.position != target.transform.position)
                {
                    current_time += Time.deltaTime;
                    var t = delta * current_time;
                    tf.position = Vector3.Lerp(user.transform.position, target.transform.position, t);
                    yield return null;
                }
                Destroy(spellShot);
            }
            else
            {
                yield return new WaitForSeconds(LAUNCHTIME);
            }
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
