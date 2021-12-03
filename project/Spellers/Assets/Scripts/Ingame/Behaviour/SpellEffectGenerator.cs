using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SpellSystem;

namespace Ingame
{
    // Genera efectos visuales al recibir / lanzar hechizos
    public class SpellEffectGenerator : MonoBehaviour
    {
        #region Inspector fields

        [SerializeField] private GameObject effect_prefab;
        [SerializeField] private Sprite heal;
        [SerializeField] private Sprite self_damage;
        [SerializeField] private Sprite shield;
        [SerializeField] private Sprite brokenShield;
        [SerializeField] private Sprite regen;
        [SerializeField] private Sprite poison;
        [SerializeField] private Sprite atkbuff;
        [SerializeField] private Sprite atkdebuff;
        [SerializeField] private Sprite castbuff;
        [SerializeField] private Sprite castDebuff;

        #endregion

        private Speller speller;
        private Stats stats;

        private Sprite GetSpriteEffect(Effect effect)
        {
            Sprite s = null;
            if(effect is HealingEffect h_effect)
            {
                s = h_effect.PointsBase > 0 ? heal : self_damage; 
            }
            else if(effect is ShieldEffect s_effect)
            {
                s = s_effect.PointsBase > 0 ? shield : brokenShield;
            }
            else if (effect is RegenerationEffect r_effect)
            {
                s = r_effect.PointsBase > 0 ? regen : poison;
            }
            else if (effect is AttackBuffEffect a_effect)
            {
                s = a_effect.PointsBase > 0 ? atkbuff : atkdebuff;
            }
            else if (effect is GameEffect g_effect)
            {
                s = g_effect.PointsBase > 0 ? castbuff : castDebuff;
            }
            return s;
        }

        private IEnumerator EffectCoroutine(Sprite sprite, Transform tf, int ticks = 20)
        {
            Vector3 pos = tf.position + Vector3.back;
            Vector3 init_pos = pos + Vector3.up; 
            Vector3 final_pos = pos + Vector3.up * 1.5f;            
            var effect_go = Instantiate(effect_prefab, tf);
            effect_go.transform.Translate(Vector3.back);
            effect_go.GetComponent<SpriteRenderer>().sprite = sprite;

            float delta = 1f / ticks;
            for (int i = 0; i < ticks; i++)
            {
                effect_go.transform.position = Vector3.Lerp(init_pos, final_pos, (i + 1) * delta);
                yield return new WaitForFixedUpdate();
            }
            Destroy(effect_go);
        }

    }

    

}
