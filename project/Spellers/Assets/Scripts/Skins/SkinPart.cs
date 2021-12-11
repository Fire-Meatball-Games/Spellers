using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Skins
{
    public class SkinPart : ScriptableObject
    {
        [SerializeField] private Sprite thumbnail;  
        [SerializeField] private int id;       

        public Sprite Thumbnail { get => thumbnail;}
        public int Id { get => id; }
    }
}

