using TMPro;
using UnityEngine;
using SpellSystem;
using UnityEngine.UI;

namespace Ingame.UI
{
    public class SpellSlotGUI : MonoBehaviour
    {
        public TextMeshProUGUI spell_name_text;
        public Image icon_L;
        public Image level_image;
        public Sprite L1, L2, L3;
        public Button button;

        public void SetSpellGUI(SpellSystem.SpellUnit spellUnit)
        {
            spell_name_text.text = spellUnit.spell.Name;
            switch (spellUnit.lvl)
            {
                case 1: level_image.sprite = L1; break;
                case 2: level_image.sprite = L2; break;
                case 3: level_image.sprite = L3; break;
                default: break;
            }
            icon_L.sprite = spellUnit.spell.Icon;
        }

        public void AddListener(UnityEngine.Events.UnityAction action)
        {
            button.onClick.AddListener(action);
        }

    }
}
