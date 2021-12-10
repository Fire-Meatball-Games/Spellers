using System.Collections;
using System.Collections.Generic;
using SpellSystem;
using TMPro;
using Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace Ingame.UI
{
    public class SpellInfoGUI : MonoBehaviour
    {
        private enum Category
        {            
            normal = 1,
            Épica = 2,
            Legendaria = 3,
        }
        [SerializeField] private RectTransform layout;
        [SerializeField] private Image icon;
        [SerializeField] private TextMeshProUGUI name_txt;
        [SerializeField] private TextMeshProUGUI power_txt;
        [SerializeField] private TextMeshProUGUI type_txt;
        [SerializeField] private TextMeshProUGUI desc_txt;

        public bool active;
        private EffectBuilder showEffects, hideEffects;

        private void Awake() => Init();
        private void Init() 
        {
            showEffects = new EffectBuilder(this)
            .AddEffect(new EnableEffect(layout.gameObject, 0, true))
            .AddEffect(new ScreenSlideEffect(layout, Vector2.left * 0.7f, Vector2.zero, 1.2f, 0.3f));

            hideEffects = new EffectBuilder(this)
            .AddEffect(new EnableEffect(layout.gameObject, 0.2f, false))
            .AddEffect(new ScreenSlideEffect(layout, Vector2.zero, Vector2.left * 0.7f, 1f, 0.2f));
        }

        public void SetUp(Spell spell)
        {
            icon.sprite = spell.Icon;
            name_txt.text = spell.Name;
            power_txt.text = ((Category) spell.Power).ToString();
            type_txt.text = spell.type.ToString();
            desc_txt.text = spell.Description;  
            Show();          
        }

        public virtual void Hide() 
        { 
            hideEffects.ExecuteEffects();
            active = false;
        }
        public virtual void Show()
        {
            active = true;
            showEffects.ExecuteEffects();
        } 

        public void HideInstant()
        {
            active = false;
            layout.gameObject.SetActive(false);
        }
    }

}
