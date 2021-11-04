using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Runtime.DialogueSystem;

namespace Runtime
{
    [CreateAssetMenu(fileName = "Level", menuName = "Spellers/Level", order = 2)]
    public class Level : ScriptableObject
    {
        public string levelname;
        public GameSettings gameSettings;
        public Dialogue dialogue;
    }

}
