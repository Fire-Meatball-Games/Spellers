using TMPro;
using UnityEngine;
using SpellSystem;
using UnityEngine.UI;

namespace Ingame.UI
{
    public class SpellSlotGUI : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI spell_name_text;
        [SerializeField] private Image icon;
        [SerializeField] private Image level_image;
        [SerializeField] private Sprite L1, L2, L3;
        [SerializeField] private Button select_button;
        [SerializeField] private Button info_button;

        public void SetSpellGUI(SpellUnit spellUnit)
        {
            spell_name_text.text = spellUnit.spell.Name;
            switch (spellUnit.lvl)
            {
                case 1: level_image.sprite = L1; break;
                case 2: level_image.sprite = L2; break;
                case 3: level_image.sprite = L3; break;
                default: break;
            }
            icon.sprite = spellUnit.spell.Icon;
        }

        public void AddSelectButtonCallback(UnityEngine.Events.UnityAction action)
        {
            select_button.onClick.AddListener(action);
        }

        public void AddInfoButtonCallback(UnityEngine.Events.UnityAction action)
        {
            select_button.onClick.AddListener(action);
        }

    }
}
