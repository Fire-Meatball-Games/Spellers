using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utils;

namespace SpellSystem
{
    public enum Type
    {
        Attack,
        Heal,
        Shield,
        Sacrifice
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
    }  

}