using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace SpellSystem
{
    [CreateAssetMenu(fileName = "SpellCollection", menuName = "Spellers/Spells/SpellCollection", order = 0)]    
    public class SpellCollection : ScriptableObject
    {   
        [SerializeField] private List<Spell> spells;

        [HideInInspector] public int NumSpells => spells.Count;
        [HideInInspector] public Spell this[int idx] => GetSpellAt(idx);

        private Spell GetSpellAt(int idx)
        {
            if(idx < 0 || idx >= spells.Count)
            {
                return null;
            }
            else
            {                
                return spells[idx];      
            }
        }
    }

}

