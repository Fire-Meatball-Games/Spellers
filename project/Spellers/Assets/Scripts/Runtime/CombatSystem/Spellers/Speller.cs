using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SpellSystem;
using CustomEventSystem;

namespace Runtime.CombatSystem
{
    public abstract class Speller : MonoBehaviour
    {
        #region Fields

        const int MAX_HEALTH = 100;

        public string spellerName;

        protected SpellerStats stats;
        public Speller target;

        #endregion

        #region Properties

        public SpellerStats Stats => stats;
        public GameObject spellPrefab;

        public delegate void OnUseSpellDelegate();
        public event OnUseSpellDelegate OnUseSpellEvent;

        #endregion

        #region Unity CallBacks

        public void Awake()
        {
            Init();
        }

        #endregion

        #region Methods

        // Inicializa las variables necesarias

        public virtual void Init()
        {
            stats = new SpellerStats(MAX_HEALTH);
        }

        // Usa un hechizo

        protected void UseSpell(Spell spell)
        {
            OnUseSpellEvent?.Invoke();
            SpellWand.UseSpell(spell, this, target);
            Debug.Log(spellerName + " -> " + spell);
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

        protected abstract Spell GetActiveSpell();

        // Corroutina para la animación del hechizo

        private IEnumerator SpellCorroutine(Spell spell, float time = 1f)
        {
            GameObject spellShot = Instantiate(spellPrefab);
            spellShot.transform.position = transform.position;
            float delta = 0;
            if (transform.position.x < target.transform.position.x)
                spellShot.GetComponent<SpriteRenderer>().flipX = true;
            for(int i = 0; i < time / Time.fixedDeltaTime; i++)
            {
                delta += Time.fixedDeltaTime;
                if(spell.isOffensive())
                    spellShot.transform.position = Vector3.Lerp(transform.position, target.transform.position, delta);
                yield return new WaitForFixedUpdate();
            }
            Destroy(spellShot);
            UseSpell(spell);
        }        
        #endregion
    }
}
