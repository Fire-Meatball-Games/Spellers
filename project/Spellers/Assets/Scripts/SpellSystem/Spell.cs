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
        [SerializeField] public bool offensive;

        [SerializeField] public List<Effect> effects;


        public override string ToString()
        {
            return spellName;
        }
    }
}