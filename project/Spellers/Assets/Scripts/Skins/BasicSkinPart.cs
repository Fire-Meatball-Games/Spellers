using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Skins
{
    [CreateAssetMenu(fileName = "BasicSkinPart", menuName = "Spellers/Skin/BasicSkinPart")]
    public class BasicSkinPart : SkinPart
    {
        public enum TypePart
        {
            hat,
            hair,
            face,
            eyes,
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

