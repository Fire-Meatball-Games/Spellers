using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Skins
{
    [CreateAssetMenu(fileName = "BasicSkinPart", menuName = "Spellers/Skin/BasicSkinPart")]
    public class BasicSkinPart : SkinPart
    {
        public static List<BasicSkinPart> GetAllSkinPartsOfType(TypePart type)
        {
            return Resources.LoadAll<BasicSkinPart>("").ToList().FindAll((basicSkinPart) => basicSkinPart.typePart == type);
        }

        public enum TypePart
        {
            hat,
            hair,
            face,
            nose,
            mouth,
            coat,
        }

        [SerializeField] private TypePart typePart; 
        [SerializeField] private Sprite spriteSkin;

        public TypePart Part { get => typePart; }
        public Sprite SpriteSkin { get => spriteSkin; }
    }
}

