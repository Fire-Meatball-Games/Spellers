using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SpellSystem;

namespace Runtime.CombatSystem
{
    public static class SpellWand 
    {
        public static void UseSpell(SpellUnit spellUnit, Speller user, Speller target)
        {
            int level = spellUnit.lvl;
            foreach(SpellEffect effect in spellUnit.spell.target_effects)
            {
                float value = effect.base_value * effect.level_value * level; 
                switch (effect.type)
                {
                    case SpellEffect.Type.Dummy:                                            break;
                    case SpellEffect.Type.Base_Damage:      BaseDamage(value, target);      break;
                    case SpellEffect.Type.Percent_Damage:   PercentDamage(value, target);   break;
                    case SpellEffect.Type.Base_Healing:     BaseHeal(value, target);        break;
                    case SpellEffect.Type.Percent_Healing:  PercentHeal(value, target);     break;
                    case SpellEffect.Type.Shields:          GetShield(value, target);       break;
                    case SpellEffect.Type.Attack:                                           break;
                    case SpellEffect.Type.Defense:                                          break;
                    default:                                                                break;
                }
            }

            foreach (SpellEffect effect in spellUnit.spell.self_effects)
            {
                float value = effect.base_value * effect.level_value * level;
                switch (effect.type)
                {
                    case SpellEffect.Type.Dummy: break;
                    case SpellEffect.Type.Base_Damage: BaseDamage(value, user); break;
                    case SpellEffect.Type.Percent_Damage: PercentDamage(value, user); break;
                    case SpellEffect.Type.Base_Healing: BaseHeal(value, user); break;
                    case SpellEffect.Type.Percent_Healing: PercentHeal(value, user); break;
                    case SpellEffect.Type.Shields: GetShield(value, user); break;
                    case SpellEffect.Type.Attack: break;
                    case SpellEffect.Type.Defense: break;
                    default: break;
                }
            }
        }

        public static void BaseDamage(float value, Speller speller)
        {
            int base_value = (int)value;
            speller.stats.GetDamage(base_value);
        }

        public static void BaseHeal(float value, Speller speller)
        {
            int base_value = (int)value;
            speller.stats.Health += base_value;
        }

        public static void PercentDamage(float value, Speller speller)
        {
            float current_hp_percentage = (float)speller.stats.Health / 100f;
            int percent_value = (int)(current_hp_percentage * value);
            speller.stats.GetDamage(percent_value);
        }

        public static void PercentHeal(float value, Speller speller)
        {
            float current_hp_percentage = (float)speller.stats.Health / 100f;
            int percent_value = (int)(current_hp_percentage * value);
            speller.stats.Health += percent_value;
        }

        public static void GetShield(float value, Speller speller)
        {
            int shields = (int)value;
            speller.stats.Shields += shields;
        }
    } 
}
