using UnityEngine;

namespace DialogueSystem
{
    public enum Layout
    {
        left,
        right
    }

    [CreateAssetMenu(menuName = "Spellers/Dialogue/Line")]
    public class DialogueLine : ScriptableObject
    {
        [SerializeField] private DialogueCharacter character;
        [TextArea]
        [SerializeField] private string text;
        [SerializeField] private Layout layout;

        public DialogueCharacter Character => character;
        public string Text => text;
        public Layout Layout => Layout;
    } 
}
