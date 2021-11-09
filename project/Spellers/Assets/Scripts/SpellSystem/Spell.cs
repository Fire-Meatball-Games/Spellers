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


    }


    [CreateAssetMenu(fileName = "Spell", menuName = "Spellers/Spell", order = 1)]
    public class Spell : ScriptableObject
    {
        [SerializeField] public string spellName;
        [TextArea]
        [SerializeField] public string description;
        [SerializeField] public Sprite thumbnail;
        [SerializeField] public Sprite ingame;

        [Range(1, 3)]
        [SerializeField] public int power = 1;

        [SerializeField] public List<SpellEffect> target_effects;
        [SerializeField] public List<SpellEffect> self_effects;



        public Spell(string spellName, string description)
        {
            this.spellName = spellName;
            this.description = description;
        }

        public static Spell DefaultSpell()
        {
            return new Spell("Dummy", "Default spell");
        }

        public override string ToString()
        {
            return spellName;
        }
    }

    [System.Serializable]
    public class SpellEffect
    {
        public enum Type
        {
            Dummy,
            Base_Damage,
            Percent_Damage,
            Base_Healing,            
            Percent_Healing,
            Shields,
            Attack,
            Defense
        }

        public Type type;
        public float base_value;
        public float level_value;
        public int base_hits = 1;
        public int level_hits = 1;
    }
}