using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Skins
{
     [CreateAssetMenu(fileName = "Skin", menuName = "Spellers/Skin/Skin")]
    public class Skin : ScriptableObject
    {
        [SerializeField] private BasicSkinPart face, hair, hat, nose, mouth, coat;
        [SerializeField] private DoubleSkinPart eyes;
        [SerializeField] private CompoundSkinPart bodyPart;
        public BasicSkinPart Face { get => face; set{ if(value.Part == BasicSkinPart.TypePart.hat) face = value;} }
        public BasicSkinPart Hair { get => hair; set{ if(value.Part == BasicSkinPart.TypePart.hair) hair = value;} }
        public BasicSkinPart Hat { get => hat; set{ if(value.Part == BasicSkinPart.TypePart.hat) hat = value;} }
        public DoubleSkinPart Eyes { get => eyes; set{ eyes = value;} }
        public BasicSkinPart Nose { get => nose; set{ if(value.Part == BasicSkinPart.TypePart.nose) nose = value;} }
        public BasicSkinPart Mouth { get => mouth; set{ if(value.Part == BasicSkinPart.TypePart.mouth) mouth = value;} }
        public BasicSkinPart Coat { get => coat; set{ if(value.Part == BasicSkinPart.TypePart.coat) coat = value;} }

        public CompoundSkinPart Body { get => bodyPart; set { bodyPart = value; }}

        public void SetSkinPart(SkinPart part)
        {
            if(part is CompoundSkinPart compoundSkinPart)
            {
                bodyPart = compoundSkinPart;
            }
            else if (part is BasicSkinPart basicSkinPart)
            {
                switch(basicSkinPart.Part)
                {
                    case BasicSkinPart.TypePart.face: face = basicSkinPart; break;
                    case BasicSkinPart.TypePart.hat: hat = basicSkinPart; break;
                    case BasicSkinPart.TypePart.hair: hair = basicSkinPart; break;                    
                    case BasicSkinPart.TypePart.nose: nose = basicSkinPart; break;
                    case BasicSkinPart.TypePart.mouth: mouth = basicSkinPart; break;
                    case BasicSkinPart.TypePart.coat: coat = basicSkinPart; break;
                }
            }
            else if (part is DoubleSkinPart doubleSkinPart)
            {
                eyes = doubleSkinPart;
            }
        }

        public bool Contains(SkinPart part)
        {
            if(part is CompoundSkinPart compoundSkinPart)
            {
                return bodyPart == compoundSkinPart;
            }
            else if (part is BasicSkinPart basicSkinPart)
            {
                switch(basicSkinPart.Part)
                {
                    case BasicSkinPart.TypePart.face: return face == basicSkinPart; 
                    case BasicSkinPart.TypePart.hat: return hat == basicSkinPart;
                    case BasicSkinPart.TypePart.hair: return hair == basicSkinPart;                    
                    case BasicSkinPart.TypePart.nose: return nose == basicSkinPart; 
                    case BasicSkinPart.TypePart.mouth: return mouth == basicSkinPart; 
                    case BasicSkinPart.TypePart.coat: return coat == basicSkinPart;
                    default: return false;
                }
            }
            else
                return false;
        }
    }

}
