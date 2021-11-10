using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SpellSystem;
using System;

namespace Runtime.CombatSystem
{
    public static class SpellWand 
    {
        public static void UseSpell(SpellUnit spellUnit, Speller user, Speller target)
        {
            int level = spellUnit.lvl;
            foreach(SpellEffect effect in spellUnit.spell.effects)
            {
                int value = effect.base_value + effect.level_value * level;
                int hits = effect.base_hits + effect.level_hits * level + 1;
                Speller speller = effect.target == SpellEffect.Target.target ? target : user;
                switch (effect.type)
                {
                    case SpellEffect.Type.Damage: Damage(value, user.stats.AttackLevel, effect.scale, hits, speller); break;
                    case SpellEffect.Type.Heal: Heal(value, effect.scale, speller); break;
                    case SpellEffect.Type.Shield: Shield(value, speller); break;
                    case SpellEffect.Type.AtkState: AttackState(value, hits, speller); break;
                    case SpellEffect.Type.Regeneration: Regeneration(value, hits, speller); break;
                    case SpellEffect.Type.CleanDebuff: CleanDebuff(speller); break;
                    case SpellEffect.Type.CleanBuff: CleanBuff(speller); break;
                    default: break;
                }
            }             
        }

        private static void CleanBuff(Speller speller)
        {
            if (speller.stats.AttackLevel > 1) speller.stats.AttackLevel = 1; speller.stats.AttacklevelTurns = 0;
            if (speller.stats.Regeneration > 0) speller.stats.Regeneration = 0; speller.stats.RegenerationTurns = 0;
            if (speller.stats.SlotLevels > 0) speller.stats.SlotLevels = 0; speller.stats.SlotLevelTurns = 0;
            if (speller.stats.Order > 0) speller.stats.Order = 0; speller.stats.OrderTurns = 0;
            if (speller.stats.Difficulty > 0) speller.stats.Difficulty = 0; speller.stats.DifficultyTurns = 0;
        }

        private static void CleanDebuff(Speller speller)
        {
            if (speller.stats.AttackLevel < 1) speller.stats.AttackLevel = 1; speller.stats.AttacklevelTurns = 0;
            if (speller.stats.Regeneration < 0) speller.stats.Regeneration = 0; speller.stats.RegenerationTurns = 0;
            if (speller.stats.SlotLevels < 0) speller.stats.SlotLevels = 0; speller.stats.SlotLevelTurns = 0;
            if (speller.stats.Order < 0) speller.stats.Order = 0; speller.stats.OrderTurns = 0;
            if (speller.stats.Difficulty < 0) speller.stats.Difficulty = 0; speller.stats.DifficultyTurns = 0;
        }

        private static void Regeneration(int value, int hits, Speller speller)
        {
            speller.stats.Regeneration += value;
            speller.stats.RegenerationTurns += hits;
        }

        private static void AttackState(int value, int hits, Speller speller)
        {
            speller.stats.AttackLevel += value / 100f;
            speller.stats.AttacklevelTurns += hits;
        }

        private static void Damage(int value, float multiplier, SpellEffect.Scale scale, int hits, Speller speller)
        {
            float aux = value * multiplier;
            if(scale == SpellEffect.Scale.Current)
            {
                value = (int)(aux * speller.stats.Health / 100f);
            } 
            else if(scale == SpellEffect.Scale.Missing)
            {
                value = (int)(aux * (100 - speller.stats.Health) / 100f);
            }
            for (int i = 0; i < hits; i++)
            {
                speller.stats.GetDamage(value);
            }            
        }

        private static void Heal(int value, SpellEffect.Scale scale, Speller speller)
        {
            if (scale == SpellEffect.Scale.Current)
            {
                value = (int)(speller.stats.Health / 100f);
            }
            else if (scale == SpellEffect.Scale.Missing)
            {
                value = (int)((100 - speller.stats.Health) / 100f);
            }
            speller.stats.Health += (value);
        }

        private static void Shield(int value, Speller speller)
        {
            speller.stats.Shields += value;           
        }
    } 
}
