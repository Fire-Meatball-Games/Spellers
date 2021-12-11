using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using PlayerManagement;
using Skins;
using CustomEventSystem;

namespace UIManagement
{
    public class SkinCardView : CardView
    {
        private static readonly string STR_USE = "Elegir";

        [SerializeField] private Button use_btn;
        [SerializeField] private TextMeshProUGUI use_txt;

        private SkinPart skinPart;
        protected override void SetContextMenu()
        {
            bool showUseContext = !Player.instance.Skin.Contains(skinPart);
            use_btn.gameObject.SetActive(showUseContext);
        }

        protected override void Init()
        {
            base.Init();
            use_btn.onClick.AddListener(OnUseThisCallback);
        }

        private void OnUseThisCallback()
        {
            Skin skin = Player.instance.Skin;
            skin.SetSkinPart(skinPart);
            hideContextMenuEffects.ExecuteEffects();
            Events.OnModifyPlayerSkin.Invoke();
            selected_cardView = null;            
        }

        public void SetUp(SkinPart skinPart, bool unlocked = true)
        {
            this.skinPart = skinPart;
            icon_img.sprite = skinPart.Thumbnail;
            lock_img.gameObject.SetActive(!unlocked);
            icon_button.interactable = unlocked;
            use_txt.text = STR_USE;
        }

    }

}
