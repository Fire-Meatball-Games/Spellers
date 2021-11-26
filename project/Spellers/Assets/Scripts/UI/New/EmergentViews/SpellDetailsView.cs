using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using SpellSystem;
using Tweening;

namespace UIManagement
{
    public class SpellDetailsView : EmergentView
    {
        private enum Category
        {            
            normal = 1,
            Épica = 2,
            Legendaria = 3,
        }

        [SerializeField] private RectTransform panel;
        [SerializeField] private Image icon;
        [SerializeField] private TextMeshProUGUI name_txt;
        [SerializeField] private TextMeshProUGUI power_txt;
        [SerializeField] private TextMeshProUGUI type_txt;
        [SerializeField] private TextMeshProUGUI desc_txt;

        public override void Init()
        {
            close_time = 0.1f;
            base.Init();
            show_effects.AddEffect(new ScreenSlideEffect(panel, Vector3.up, Vector3.zero, 1.1f, 0.2f));
            hide_effects.AddEffect(new ScreenSlideEffect(panel, Vector3.zero, Vector2.up, 1f, 0.1f));
        }

        public void SetUp(Spell spell)
        {
            icon.sprite = spell.thumbnail;
            name_txt.text = spell.spellName;
            power_txt.text = ((Category) spell.power).ToString();
            type_txt.text = spell.type.ToString();
            desc_txt.text = spell.description;            
        }

    }

}
