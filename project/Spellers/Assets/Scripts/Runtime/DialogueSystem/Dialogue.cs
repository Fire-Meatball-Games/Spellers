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
            private Queue<DialogueLine> lines; 

            public Queue<DialogueLine> Lines => lines;

            public DialogueLine GetNextLine()
            {
                return lines.Dequeue();
            }
        } 
    }
}