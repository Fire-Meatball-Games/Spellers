using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SpellSystem;
using CustomEventSystem;
using Skins;


namespace Ingame
{
    public abstract class Speller : MonoBehaviour
    {
        #region Inspector Fields
        [SerializeField] protected SpellerAnimator spellerAnimator;
        [SerializeField] protected SkinDrawer skinDrawer;
        [SerializeField] protected SpellWand spellWand;
        [SerializeField] protected SpellEffectGenerator spellEffectGenerator;

        #endregion
        
        #region Public fields
        private string spellerName;
        private Sprite icon;
        private Stats stats;

        #endregion

        #region Properties
        public Stats Stats { get => stats; }
        public Sprite Icon { get => icon; set => icon = value; }
        public string SpellerName { get => spellerName; set => spellerName = value;}

        #endregion

        #region Initialization

        private void Start()
        {
            stats = new Stats();
            Stats.OnGetHitEvent += spellerAnimator.SetDamagedAnim;
        }

        public void SetTarget(Speller target)
        {
            spellWand.SetUp(this, target);
        }        

        public abstract void Active();

        #endregion

        #region Private Methods

        // Usa un hechizo
        protected virtual void UseSpell(SpellUnit spellUnit)
        {            
            Stats.CompleteTurn();
        }

        // Devuelve el hechizo que va a lanzar el personaje (implementar en subclases)
        protected abstract SpellUnit GetActiveSpell();

        // Lanza el hechizo activo
        public virtual void LaunchSpell()
        {
            SpellUnit unit = GetActiveSpell();
            spellWand.LaunchSpell(unit);
        }

        
        
       
        #endregion
    }
}
