using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SpellSystem;

namespace Runtime.CombatSystem
{
    public abstract class Speller : MonoBehaviour
    {
        #region Fields

        const int MAX_HEALTH = 100;

        public string spellerName;

        protected SpellerStats stats;
        protected Speller target;

        #endregion

        #region Properties

        public SpellerStats Stats => stats;

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
            Debug.Log(gameObject.name + " --> " + spell.ToString());
            OnUseSpellEvent?.Invoke();
            SpellWand.UseSpell(spell, this, target);
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
            // Lanzar animación
            yield return new WaitForSeconds(time);
            UseSpell(spell);
        }

        #endregion
    }
}
