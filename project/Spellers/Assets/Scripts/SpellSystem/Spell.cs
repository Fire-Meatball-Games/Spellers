using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpellSystem
{
    public struct SpellUnit
    {
        public Spell spell;
        public int lvl;

        public SpellUnit(Spell spell, int lvl)
        {
            this.spell = spell;
            this.lvl = spell.power < 3 ? lvl : 3;
        }

        public SpellUnit(Spell spell)
        {            
            this.spell = spell;
            this.lvl = spell.power < 3 ? Random.Range(1,3) : 3;
        }

        public override string ToString()
        {
            return spell.spellName + " " + lvl;
        }
    }


    [CreateAssetMenu(fileName = "Spell", menuName = "Spellers/Spells/Spell", order = 0)]
    public class Spell : ScriptableObject
    {
        [SerializeField] public string spellName;
        [TextArea]
        [SerializeField] public string description;
        [SerializeField] public Sprite thumbnail;
        [SerializeField] public Sprite ingame;

        [Range(1, 3)]
        [SerializeField] public int power = 1;

        [SerializeField] public List<SpellEffect> effects;


        public override string ToString()
        {
            return spellName;
        }
    }

    [System.Serializable]
    public class SpellEffect
    {
        public enum Target
        {
            target = 0,
            self = 1
        }

        public enum Type
        {
            Damage = 0,
            Heal = 1,
            Shield = 2,
            AtkState = 3,
            DefState = 4,
            Regeneration = 5,
            CleanDebuff = 6,
            CleanBuff = 7,
            Difficulty = 10,
            Slots = 11,
            Order = 12
        }

        public enum Scale
        {
            Plane = 0,
            Missing = 1,
            Current = 2
        }

        public Target target;
        public Type type;
        public Scale scale;
        public int base_value;
        public int level_value;
        public int base_hits;
        public int level_hits;
    }
}