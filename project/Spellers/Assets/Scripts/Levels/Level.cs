using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueSystem;

namespace Levels
{
    [CreateAssetMenu(fileName = "Level", menuName = "Spellers/Level", order = 2)]

    public class Level : ScriptableObject
    {
        [SerializeField] public string levelname;
        [SerializeField] public Sprite thumbnail;
        [SerializeField] public Dialogue map_dialogue;
        [SerializeField] public LevelGameSettings settings;
              
    }

}
