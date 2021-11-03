using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Runtime
{
    [CreateAssetMenu(fileName = "Level", menuName = "Spellers/Level", order = 2)]
    public class Level : ScriptableObject
    {
        public string levelname;
        public GameSettings gameSettings;
    }

}
