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




            //switch (spell.type)
            //{
            //    case Type.Dummy:
            //        // No hace nada
            //        break;
            //    case Type.Attack:
            //        int baseDmg = DMG_BASE + DMG_LVL * spell.lvl;
            //        int dmg = (int)((BUFF_BASE + (user.stats.AttackLevel - target.stats.DefenseLevel) * BUFF_LVL) * baseDmg);
            //        target.GetDamage(dmg);
            //        break;
            //    case Type.Heal:
            //        int baseHeal = HEAL_BASE + HEAL_LVL * spell.lvl;
            //        user.stats.Health += baseHeal;
            //        break;
            //    case Type.Shield:
            //        int baseShield = SHIELD_BASE + SHIELD_LVL * spell.lvl;
            //        user.stats.Shields += baseShield;
            //        break;
            //    case Type.Sacrifice:
            //        int targetBaseDmg = SACRIFICE_DMG_BASE + SACRIFICE_DMG_LVL * spell.lvl;
            //        int targetDmg = (int)((BUFF_BASE + (user.stats.AttackLevel - target.stats.DefenseLevel) * BUFF_LVL) * targetBaseDmg);
            //        target.stats.GetDamage(targetDmg);
            //        int selfDamage = SACRIFICE_SELF_DMG_BASE + SACRIFICE_SELF_DMG_LVL * spell.lvl;
            //        user.stats.GetDamage(selfDamage);
            //        break;
            //    case Type.AtkBuff:
            //        user.stats.AttackLevel += spell.lvl;
            //        break;
            //    case Type.AtkDebuff:
            //        target.stats.AttackLevel -= spell.lvl;
            //        break;
            //    case Type.DefBuff:
            //        user.stats.DefenseLevel += spell.lvl;
            //        break;
            //    case Type.DefDebuff:
            //        target.stats.DefenseLevel -= spell.lvl;
            //        break;
            //    default:
            //        break;
            //}
        }
    } 
}
