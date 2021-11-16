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
        public SpellerStats stats = new SpellerStats(); 
        public Speller target;
        public SpellWand spellWand;
        #endregion

        #region Properties

        // Borrar:
        public GameObject spellPrefab;
        #endregion

        #region Methods

        // Usa un hechizo

        protected virtual void UseSpell(SpellUnit spellUnit)
        {
            spellWand?.UseSpell(spellUnit, this, target);
            stats.CompleteTurn();
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
            if (spellUnit.spell.offensive)
            {
                GameObject spellShot = Instantiate(spellPrefab);
                Sprite sprite = spellUnit.spell.ingame;
                if(sprite != null)
                    spellShot.GetComponent<SpriteRenderer>().sprite = sprite;
                spellShot.transform.position = transform.position;
                float delta = 0;
                if (transform.position.x < target.transform.position.x)
                    spellShot.GetComponent<SpriteRenderer>().flipX = true;
                for (int i = 0; i < time / Time.fixedDeltaTime; i++)
                {
                    delta += Time.fixedDeltaTime;

                    spellShot.transform.position = Vector3.Lerp(transform.position, target.transform.position, delta);
                    yield return new WaitForFixedUpdate();
                }
                Destroy(spellShot);                
            }
            else
            {
                yield return new WaitForSeconds(time);
            }
            UseSpell(spellUnit);
        }        
        #endregion
    }
}
