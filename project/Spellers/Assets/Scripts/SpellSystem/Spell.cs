using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using System.Linq;

namespace SpellSystem
{
    [CreateAssetMenu(fileName = "Spell", menuName = "Spellers/Spells/Spell", order = 0)]
    public class Spell : ScriptableObject
    {
        public static Spell GetSpellById(int id) 
        {
            List<Spell> spells = GetAllSpells();            
            return spells.Find((spell) => spell.Id == id);
        }

        public static Spell GetSpellByName(string name) 
        {
            List<Spell> spells = GetAllSpells();            
            return spells.Find((spell) => spell.Name == name);
        }

        public static List<Spell> GetAllSpellsOfType(Type type)
        {
            List<Spell> spells = GetAllSpells();            
            return spells.FindAll((spell) => spell.type == type);
        }

        public static List<Spell> GetAllSpellsOfCategory(SpellCategory category)
        {
            List<Spell> spells = GetAllSpells();            
            return spells.FindAll((spell) => spell.Category == category);
        }

        public static List<Spell> GetAllSpells()
        {
            return Resources.LoadAll<Spell>("").ToList();
        }

        public enum Type
        {
            Ataque = 0,
            Defensa = 1,
            Mejora = 2,
            Debilitación = 3
        }

        public enum SpellCategory
        {
            Useless = 0,
            Common = 1,
            Rare = 2,
            Epic = 3
        }

        public enum AnimationType
        {            
            proyectile,
            self,
            target
        }

        [SerializeField] private int id;
        [SerializeField] private string spellname;
        [TextArea][SerializeField] private string description;
        [SerializeField] private Sprite icon;
        [SerializeField] private GameObject animation;
        [SerializeField] private SpellCategory category;
        [SerializeField] public AnimationType animationType;
        [SerializeField] public Type type;
        [SerializeField] public List<Effect> effects;

        public string Name { get => spellname; }
        public int Id { get => id; }
        public string Description { get => description; }
        public Sprite Icon { get => icon; }
        public GameObject Animation { get => animation; }
        public int Power { get => (int)category; }

        public SpellCategory Category => category;

        public override string ToString()
        {
            return Name;
        }


        
    }
}