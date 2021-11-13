using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Runtime.CombatSystem;
using SpellSystem;
using Runtime.DialogueSystem;

namespace Runtime
{
    [System.Serializable]
    public class GameSettings
    {
        // Detalles
        [SerializeField] public List<SpellerNPCSettings> speller_Settings;
        public Dialogue init_dialogue;
        public Dialogue end_dialogue;
    } 
}

