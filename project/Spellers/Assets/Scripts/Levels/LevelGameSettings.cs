using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SpellSystem;
using DialogueSystem;

namespace Levels
{
    [CreateAssetMenu(fileName = "Level", menuName = "Spellers/Game/Level", order = 0)]
    public class LevelGameSettings : BaseGameSettings
    {
        [SerializeField] private int levelIndex;
        [SerializeField] private string levelname;
        [SerializeField] private Sprite thumbnail;
        [SerializeField] private SpellDeck playerDeck;

        [SerializeField] private Dialogue mapDialogue;
        [SerializeField] private Dialogue initDialogue;
        [SerializeField] private Dialogue endDialogue;

        public int LevelIndex { get => levelIndex; }
        public string Levelname { get => levelname; }
        public Sprite Thumbnail { get => thumbnail; }
        public SpellDeck PlayerDeck { get => playerDeck; }
        public Dialogue MapDialogue { get => mapDialogue; }
        public Dialogue InitDialogue { get => initDialogue; }
        public Dialogue EndDialogue { get => endDialogue; }
        
    }
 
}
