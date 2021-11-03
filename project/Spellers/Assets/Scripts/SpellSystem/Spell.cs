using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpellSystem
{
    public enum Type
    {
        Dummy,
        Attack,
        Heal,
        Shield,
        Sacrifice,
        AtkBuff,
        DefBuff,
        AtkDebuff,
        DefDebuff
    }

    [CreateAssetMenu(fileName = "Spell", menuName = "Spellers/Spell", order = 1)]
    public class Spell : ScriptableObject
    {
        public string spellName;
        [TextArea] public string description;
        public int lvl;
        
        public Type type;

        public Spell(string spellName, string description, int lvl, Type type)
        {
            this.spellName = spellName;
            this.description = description;
            this.lvl = lvl;
            this.type = type;
        }

        public static Spell DefaultSpell()
        {
            return new Spell("Dummy", "Default spell", 1, Type.Dummy);
        }

        public override string ToString()
        {
            return spellName + " Lvl." + lvl;
        }

        public bool isOffensive()
        {
            return type == Type.Attack || type == Type.Sacrifice || type == Type.AtkDebuff || type == Type.DefDebuff;
        }
    }  

}