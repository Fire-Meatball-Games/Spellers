using System;
using System.Collections;
using System.Collections.Generic;
using PlayerManagement;
using Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace UIManagement
{
    public abstract class CardView : MonoBehaviour
    {
        public static CardView selected_cardView;
        public static event Action OnSelectCard = delegate { };
        
        [SerializeField] protected Sprite default_icon;
        [SerializeField] protected Image icon_img; 
        [SerializeField] protected Button icon_button;
        [SerializeField] protected Image lock_img;
        [SerializeField] protected RectTransform contextMenu_rt;
        protected EffectBuilder showContextMenuEffects, hideContextMenuEffects;

        #region Public Methods
        private void Awake() 
        {
           Init();
        }
        protected virtual void Init()
        {
             showContextMenuEffects = new EffectBuilder(this)
                .AddEffect(new ScaleRectEffect(contextMenu_rt, Vector3.zero, Vector3.one, 1.2f, 0.2f));
            hideContextMenuEffects = new EffectBuilder(this)
                .AddEffect(new ScaleRectEffect(contextMenu_rt, Vector3.one, Vector3.zero, 1f, 0.2f));

            icon_button.onClick.AddListener(OnSelectThisCallback);
        }

        private void OnEnable() 
        {
            OnSelectCard += OnSelectOtherCallback;
        }

        private void OnDisable() 
        {
            OnSelectCard -= OnSelectOtherCallback;
        }
        #endregion

        // Este metodo se lanza cuando pulsas esta carta
        private void OnSelectThisCallback()
        {
            if(selected_cardView != this)
            {
                OnSelectCard?.Invoke();
                SetContextMenu();
                showContextMenuEffects.ExecuteEffects();
                selected_cardView = this;
            }   
            else
            {
                hideContextMenuEffects.ExecuteEffects();
                selected_cardView = null;
            }                 
        }

        // Este metodo se lanza cuando pulsas cualquier otra carta
        private void OnSelectOtherCallback()
        {
            if(selected_cardView == this){
                hideContextMenuEffects.ExecuteEffects();
                selected_cardView = this;
            }
        }


        protected abstract void SetContextMenu();
        

    }
}
