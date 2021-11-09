using TMPro;
using UnityEngine;
using SpellSystem;
using UnityEngine.UI;

namespace Runtime.CombatSystem.UI
{
    public class SpellSlotGUI : MonoBehaviour
    {
        public TextMeshProUGUI spell_name_text;
        public TextMeshProUGUI spell_level_text;
        public Button button;

        public void SetSpellGUI(SpellUnit spellUnit)
        {
            spell_name_text.text = spellUnit.spell.spellName;
            spell_level_text.text = "Lvl " + spellUnit.lvl;
        }

        public void AddListener(UnityEngine.Events.UnityAction action)
        {
            button.onClick.AddListener(action);
        }

    }
}
