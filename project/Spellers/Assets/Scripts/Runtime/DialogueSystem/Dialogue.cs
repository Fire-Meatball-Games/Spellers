using UnityEngine;
using System.Collections.Generic;

namespace Runtime
{
    namespace DialogueSystem
    {
        [CreateAssetMenu(menuName = "Spellers/Dialogue/Dialogue")]
        public class Dialogue : ScriptableObject
        {
            [SerializeField]
            private List<DialogueLine> lines; 

            public DialogueLine GetLine(int n)
            {
                return lines[n];
            }

            public int GetNumLines() => lines.Count;
        } 
    }
}