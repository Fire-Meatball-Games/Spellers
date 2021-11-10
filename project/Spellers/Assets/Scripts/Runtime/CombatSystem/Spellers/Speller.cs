using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SpellSystem;
using CustomEventSystem;

namespace Runtime.CombatSystem
{
    public abstract class Speller : MonoBehaviour
    {
        #region Public fields

        public string spellerName;
        public SpellSystem.SpellerStats stats; 
        public Speller target;

        #endregion

        #region Properties

        // Borrar:
        public GameObject spellPrefab;

        #endregion

        #region Unity CallBacks

        #endregion

        #region Methods

        // Usa un hechizo

        protected virtual void UseSpell(SpellUnit spellUnit)
        {
            SpellWand.UseSpell(spellUnit, this, target);

        }

        // Recibe daño

        public void GetDamage(int n)
        {
            stats.GetDamage(n);
        }


        #endregion

        #region Private Methods

        // Lanza el hechizo activo

        public virtual void LaunchSpell()
        {
            IEnumerator spellCorroutine = SpellCorroutine(GetActiveSpell());
            StartCoroutine(spellCorroutine);
        }

        // Devuelve el hechizo que va a lanzar el personaje (implementar en subclases).

        protected abstract SpellUnit GetActiveSpell();


        // Corroutina para la animación del hechizo

        private IEnumerator SpellCorroutine(SpellUnit spellUnit, float time = 1f)
        {
            GameObject spellShot = Instantiate(spellPrefab);
            spellShot.transform.position = transform.position;
            float delta = 0;
            if (transform.position.x < target.transform.position.x)
                spellShot.GetComponent<SpriteRenderer>().flipX = true;
            for(int i = 0; i < time / Time.fixedDeltaTime; i++)
            {
                delta += Time.fixedDeltaTime;

                    spellShot.transform.position = Vector3.Lerp(transform.position, target.transform.position, delta);
                yield return new WaitForFixedUpdate();
            }
            Destroy(spellShot);
            UseSpell(spellUnit);
        }        
        #endregion
    }
}
