using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UIManagement
{
    public class SkinsView : MenuView
    {
        [SerializeField] private SkinCollectionGUI skinCollectionGUI;
        public override void Init()
        {
            skinCollectionGUI.Init();
        }
    }
}
