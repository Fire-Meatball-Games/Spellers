using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Skins
{
    public class CompoundSkinPart : SkinPart
    {
         public static List<CompoundSkinPart> GetAllSkinParts()
        {
            return Resources.LoadAll<CompoundSkinPart>("").ToList();
        }
        [SerializeField] private Sprite bodySkin;
        [SerializeField] private Sprite leftLegSkin;
        [SerializeField] private Sprite rightLegSkin;
        [SerializeField] private Sprite leftArmSkin;
        [SerializeField] private Sprite rightArmSkin;

        public Sprite RightArmSkin { get => rightArmSkin; }
        public Sprite LeftArmSkin { get => leftArmSkin;}
        public Sprite RightLegSkin { get => rightLegSkin; }
        public Sprite LeftLegSkin { get => leftLegSkin; }
        public Sprite BodySkin { get => bodySkin;  }
    }
}

