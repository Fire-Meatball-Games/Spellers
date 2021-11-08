using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Runtime.CombatSystem;
using SpellSystem;

namespace Runtime
{
    [System.Serializable]
    public class GameSettings
    {
        [SerializeField] public List<SpellerNPCSettings> speller_Settings;
    } 
}

