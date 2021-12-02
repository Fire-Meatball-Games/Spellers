using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Skins;
using PlayerManagement;
using Utils;
using CustomEventSystem;

namespace UIManagement
{
    public class PlayerSkinGUI : MonoBehaviour
    {
        [SerializeField] private SkinDrawer drawer;
    
        private void OnEnable() 
        {
            Events.OnModifyPlayerSkin.AddListener(UpdatePlayerSkin);
        }

        private void OnDisable() 
        {
            Events.OnModifyPlayerSkin.RemoveListener(UpdatePlayerSkin);
        }
        
        private void UpdatePlayerSkin()
        {
            Skin skin = Player.instance.Skin;
            drawer.UpdateSkin(skin);
        }
    }

    
}
