using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SpellSystem;

namespace Runtime.CombatSystem
{
    public static class SpellWand 
    {
        const int DMG_BASE = 6;
        const int DMG_LVL = 2;
        const int HEAL_BASE = 2;
        const int HEAL_LVL = 2;
        const int SHIELD_BASE = 4;
        const int SHIELD_LVL = 2;
        const int SACRIFICE_DMG_BASE = 10;
        const int SACRIFICE_DMG_LVL = 5;
        const int SACRIFICE_SELF_DMG_BASE = 4;
        const int SACRIFICE_SELF_DMG_LVL = 2;
        const float BUFF_BASE = 1;
        const float BUFF_LVL = 0.25f;

        public static void UseSpell(Spell spell, Speller user, Speller target)
        {
            switch (spell.type)
            {
                case Type.Dummy:
                    // No hace nada
                    break;
                case Type.Attack:
                    int baseDmg = DMG_BASE + DMG_LVL * spell.lvl;
                    int dmg = (int)((BUFF_BASE + (user.Stats.AttackLevel - target.Stats.DefenseLevel) * BUFF_LVL) * baseDmg);
                    target.GetDamage(dmg);
                    break;
                case Type.Heal:
                    int baseHeal = HEAL_BASE + HEAL_LVL * spell.lvl;
                    user.Stats.Health += baseHeal;
                    break;
                case Type.Shield:
                    int baseShield = SHIELD_BASE + SHIELD_LVL * spell.lvl;
                    user.Stats.Shield += baseShield;
                    break;
                case Type.Sacrifice:
                    int targetBaseDmg = SACRIFICE_DMG_BASE + SACRIFICE_DMG_LVL * spell.lvl;
                    int targetDmg = (int)((BUFF_BASE + (user.Stats.AttackLevel - target.Stats.DefenseLevel) * BUFF_LVL) * targetBaseDmg);
                    target.Stats.GetDamage(targetDmg);
                    int selfDamage = SACRIFICE_SELF_DMG_BASE + SACRIFICE_SELF_DMG_LVL * spell.lvl;
                    user.Stats.GetDamage(selfDamage);
                    break;
                case Type.AtkBuff:
                    user.Stats.AttackLevel += spell.lvl;
                    break;
                case Type.AtkDebuff:
                    target.Stats.AttackLevel -= spell.lvl;
                    break;
                case Type.DefBuff:
                    user.Stats.DefenseLevel += spell.lvl;
                    break;
                case Type.DefDebuff:
                    target.Stats.DefenseLevel -= spell.lvl;
                    break;
                default:
                    break;
            }
        }
    } 
}
