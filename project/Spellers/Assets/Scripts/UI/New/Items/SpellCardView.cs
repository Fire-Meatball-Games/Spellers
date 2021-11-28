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
    public class SpellCardView : MonoBehaviour
    {
        public static event Action onSelectSpellCard = delegate { };
        private static readonly string STR_USE = "Usar";
        private static readonly string STR_REMOVE = "Quitar";
        [SerializeField] private Image icon_img;        
        [SerializeField] private Image lock_img;
        [SerializeField] private RectTransform contextMenu_rt;
        [SerializeField] private Button icon_button;
        [SerializeField] private Button info_btn;
        [SerializeField] private Button use_btn;
        [SerializeField] private TextMeshProUGUI use_txt;
        [SerializeField] private Sprite default_icon;

        private bool selected;
        private Spell spell;

        private bool inDeck;

        private EffectBuilder showContextMenuEffects, hideContextMenuEffects;

        private void Awake() 
        {
             showContextMenuEffects = new EffectBuilder(this)
                .AddEffect(new ScaleRectEffect(contextMenu_rt, Vector3.zero, Vector3.one, 1.2f, 0.2f));
            hideContextMenuEffects = new EffectBuilder(this)
                .AddEffect(new ScaleRectEffect(contextMenu_rt, Vector3.one, Vector3.zero, 1f, 0.2f));

            icon_button.onClick.AddListener(OnClickIcon);
            use_btn.onClick.AddListener(OnClickUse);
            info_btn.onClick.AddListener(OnClickInfo);
        }
        
        private void OnEnable() 
        {
            onSelectSpellCard += OnSelectOtherCallback;
        }

        private void OnDisable() 
        {
            onSelectSpellCard -= OnSelectOtherCallback;
        }

        private void OnClickIcon()
        {
            if(!selected)
            {
                onSelectSpellCard?.Invoke();
                SetContextMenu();
                showContextMenuEffects.ExecuteEffects();
                selected = true;                
            }   
            else
            {
                hideContextMenuEffects.ExecuteEffects();
                selected = false;
            }                 
        }

        private void SetContextMenu()
        {
            bool showUseContext = inDeck || (!PlayerSettings.instance.SelectedDeck.Contains(spell)&& !PlayerSettings.instance.SelectedDeck.isFull());
            use_btn.gameObject.SetActive(showUseContext);
        }
        
        private void OnClickInfo()
        {
            Events.OnDisplaySpellDetails.Invoke(spell);
        }

        private void OnClickUse()
        {
            SpellDeck currentDeck = PlayerSettings.instance.SelectedDeck;
            Debug.Log("B"); 
            if(!inDeck && currentDeck.CanAdd(spell))
            {
                currentDeck.AddSpell(spell);                   
            }
            else
            {
                currentDeck.RemoveSpell(spell);        
                Debug.Log("A");        
            }
            Events.OnAddSpellToDeck.Invoke();
            hideContextMenuEffects.ExecuteEffects(); 
            selected = false;    
            
        }

        private void OnSelectOtherCallback()
        {
            if(selected){
                hideContextMenuEffects.ExecuteEffects();
                selected = false;
            }
        }

        public void SetUp(Spell spell, bool inDeck, bool unlocked = true)
        {           
            this.inDeck = inDeck;
            this.spell = spell;
            icon_img.sprite = spell.thumbnail;
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

