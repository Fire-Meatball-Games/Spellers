using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Skins
{

    [CreateAssetMenu(fileName = "DoubleSkinPart", menuName = "Spellers/Skin/DoubleSkinPart")]    
    public class DoubleSkinPart : SkinPart
    {
        public static List<DoubleSkinPart> GetAllSkinParts()
        {
            return Resources.LoadAll<DoubleSkinPart>("").ToList();
        }
        [SerializeField] private Sprite left_eye;
        [SerializeField] private Sprite right_eye;

        public Sprite RightEye { get => right_eye; }
        public Sprite LeftEye { get => left_eye; }
    }
}

