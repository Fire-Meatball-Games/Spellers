using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DialogueSystem
{
    [CreateAssetMenu(menuName = "Spellers/Dialogue/Character")]
    public class DialogueCharacter : ScriptableObject
    {
        [SerializeField] private string characterName;
        [SerializeField] public Sprite sprite;

        public string CharacterName => characterName;
        public Sprite Sprite => sprite;
    }
}
