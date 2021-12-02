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
        [SerializeField] private GameObject spellPrefab;

        #endregion
        
        #region Public fields
        private string spellerName;
        private Sprite icon;
        private Stats stats = new Stats();
        protected Speller target;

        #endregion

        #region Properties
        public Stats Stats { get => stats; }
        public Sprite Icon { get => icon; set => icon = value; }
        public string SpellerName { get => spellerName; set => spellerName = value;}

        #endregion

        #region Methods

        private void Start()
        {
            Stats.OnGetHitEvent += spellerAnimator.SetDamagedAnim;
        }

        public abstract void SetUp();

        // Usa un hechizo
        protected virtual void UseSpell(SpellSystem.SpellUnit spellUnit)
        {
            spellWand?.UseSpell(spellUnit, this, target);
            Stats.CompleteTurn();
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

        protected abstract SpellSystem.SpellUnit GetActiveSpell();


        // Corroutina para la animaci�n del hechizo

        private IEnumerator SpellCorroutine(SpellSystem.SpellUnit spellUnit, float time = 1f)
        {
            spellerAnimator.SetUseSpellAnim();
            yield return new WaitForSeconds(0.5f);
            if (spellUnit.spell.offensive)
            {
                GameObject spellShot = Instantiate(spellPrefab);
                Sprite sprite = spellUnit.spell.Sprite;
                if(sprite != null)
                    spellShot.GetComponent<SpriteRenderer>().sprite = sprite;
                spellShot.transform.position = transform.position;
                float delta = 0;
                if (transform.position.x > target.transform.position.x)
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
