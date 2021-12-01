using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Tweening;
using CustomEventSystem;
using SpellSystem;
using PlayerManagement;

namespace UIManagement
{
    public class SpellCardView : CardView
    {
        private static readonly string STR_USE = "Usar";
        private static readonly string STR_REMOVE = "Quitar";
        [SerializeField] private Button info_btn;
        [SerializeField] private Button use_btn;
        [SerializeField] private TextMeshProUGUI use_txt;

        private bool selected;
        private Spell spell;

        private bool inDeck;

        protected override void Init()
        {
            base.Init();
            use_btn.onClick.AddListener(OnUseThisCallback);
            info_btn.onClick.AddListener(OnClickInfo);
        } 
        protected override void SetContextMenu()
        {
            bool showUseContext = inDeck || (!PlayerSettings.instance.SelectedDeck.Contains(spell)&& !PlayerSettings.instance.SelectedDeck.isFull());
            use_btn.gameObject.SetActive(showUseContext);
        }
        
        private void OnClickInfo()
        {
            Events.OnDisplaySpellDetails.Invoke(spell);
        }

        private void OnUseThisCallback()
        {
            SpellDeck currentDeck = PlayerSettings.instance.SelectedDeck;
            if(!inDeck && currentDeck.CanAdd(spell))
            {
                currentDeck.AddSpell(spell);                   
            }
            else
            {
                currentDeck.RemoveSpell(spell);       
            }
            hideContextMenuEffects.ExecuteEffects(); 
            Events.OnModifyPlayerDeck.Invoke();            
            selected_cardView = null;    
            
        }

        public void SetUp(Spell spell, bool inDeck, bool unlocked = true)
        {           
            this.inDeck = inDeck;
            this.spell = spell;
            icon_img.sprite = spell.Icon;
            lock_img.gameObject.SetActive(!unlocked);
            icon_button.interactable = unlocked;      
            use_txt.text = inDeck ? STR_REMOVE : STR_USE;  
        }

        public void SetUp()
        {
            icon_img.sprite = default_icon;
            lock_img.gameObject.SetActive(false);
            icon_button.interactable = false;
        }     

    }
}

