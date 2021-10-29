using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utils;

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
        [UniqueIdentifier]
        public string id;

        public string spellName;
        [TextArea] public string description;
        public int lvl;
        
        public Type type;

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