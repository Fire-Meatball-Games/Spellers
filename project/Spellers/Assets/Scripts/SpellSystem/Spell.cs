using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpellSystem
{
    [CreateAssetMenu(fileName = "Spell", menuName = "Spellers/Spells/Spell", order = 0)]
    public class Spell : ScriptableObject
    {
        public enum Type
        {
            Ataque = 0,
            Defensa = 1,
            Mejora = 2,
            Debilitación = 3
        }
        [SerializeField] public string spellName;
        [TextArea]
        [SerializeField] public string description;
        [SerializeField] public Sprite thumbnail;
        [SerializeField] public Sprite ingame;

        [Range(1, 3)]
        [SerializeField] public int power = 1;
        [SerializeField] public bool offensive;
        [SerializeField] public Type type;

        [SerializeField] public List<Effect> effects;


        public override string ToString()
        {
            return spellName;
        }
    }
}