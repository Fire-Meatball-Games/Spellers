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
            //Debug.Log(user.spellerName + " (" + spellUnit.ToString() + ") -> " + target);
            //Debug.Log("Efectos al objetivo: " + spellUnit.spell.target_effects.Count);
            //Debug.Log("Efectos al usuario: " + spellUnit.spell.self_effects.Count);
            //int level = spellUnit.lvl;
            //foreach(SpellEffect effect in spellUnit.spell.target_effects)
            //{
            //    int value = effect.base_value + effect.level_value * level; 
            //    switch (effect.type)
            //    {
            //        case SpellEffect.Type.Dummy:                                            break;
            //        case SpellEffect.Type.Base_Damage:      BaseDamage(value, target);      break;
            //        case SpellEffect.Type.Current_Damage:   PercentDamage(value, target);   break;
            //        case SpellEffect.Type.Base_Healing:     BaseHeal(value, target);        break;
            //        case SpellEffect.Type.Current_Healing:  PercentHeal(value, target);     break;
            //        case SpellEffect.Type.Shields:          GetShield(value, target);       break;
            //        case SpellEffect.Type.AttackPower:                                           break;
            //        case SpellEffect.Type.DefensePower:                                          break;
            //        default:                                                                break;
            //    }
            //}

            //foreach (SpellEffect effect in spellUnit.spell.self_effects)
            //{
            //    int value = effect.base_value + effect.level_value * level;
            //    switch (effect.type)
            //    {
            //        case SpellEffect.Type.Dummy: break;
            //        case SpellEffect.Type.Base_Damage: BaseDamage(value, user); break;
            //        case SpellEffect.Type.Current_Damage: PercentDamage(value, user); break;
            //        case SpellEffect.Type.Base_Healing: BaseHeal(value, user); break;
            //        case SpellEffect.Type.Current_Healing: PercentHeal(value, user); break;
            //        case SpellEffect.Type.Shields: GetShield(value, user); break;
            //        case SpellEffect.Type.AttackPower: break;
            //        case SpellEffect.Type.DefensePower: break;
            //        default: break;
            //    }
            //}
        }

        public static void BaseDamage(int value, Speller speller)
        {
            speller.stats.GetDamage(value);
            Debug.Log("Set damage (" + value + ") to "+ speller.name);
        }

        public static void BaseHeal(int value, Speller speller)
        {
            speller.stats.Health += value;
            Debug.Log("Set heal (" + value + ") to " + speller.name);
        }

        public static void PercentDamage(int value, Speller speller)
        {
            float current_hp_percentage = speller.stats.Health / 100f;
            int percent_value = (int)(current_hp_percentage * value);
            speller.stats.GetDamage(percent_value);
        }

        public static void PercentHeal(float value, Speller speller)
        {
            float current_hp_percentage = speller.stats.Health / 100f;
            int percent_value = (int)(current_hp_percentage * value);
            speller.stats.Health += percent_value;
        }

        public static void GetShield(int value, Speller speller)
        {
            speller.stats.Shields += value;
            Debug.Log("Set shield (" + value + ") to " + speller.name);
        }
    } 
}
