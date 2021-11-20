using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using SpellSystem;
using Runtime;

public class SpellSelector : MonoBehaviour
{
    public List<Spell> spells;
    public TextMeshProUGUI spellName_text;
    public TextMeshProUGUI description_text;

    public List<GameObject> spellDeckslot_panels;

    private int selected_spell_idx = -1;

    private void OnEnable()
    {
        if (PlayerSettings.deck == null) PlayerSettings.deck = new SpellDeck();
        if (PlayerSettings.deck.spells.Count < 10)
        {
            PlayerSettings.deck.spells.Clear();
            for (int i = 0; i < 10; i++)
            {
                PlayerSettings.deck.AddSpell(spells[0]);
            }

        }
        for (int i = 0; i < spellDeckslot_panels.Count; i++)
        {
            if(i < PlayerSettings.deck.spells.Count)
            {
                spellDeckslot_panels[i].GetComponentInChildren<Image>().sprite = PlayerSettings.deck.spells[i].thumbnail;
                spellDeckslot_panels[i].GetComponentInChildren<Image>().color = new Color(1, 1, 1, 1);
            }
            else
            {
                spellDeckslot_panels[i].GetComponentInChildren<Image>().color = new Color(0, 0, 0, 0);
            }
        }
    }

    public void SelectSpellFromList(int idx)
    {
        selected_spell_idx = idx;
        Spell spell = spells[idx];
        spellName_text.text = spell.spellName;
        description_text.text = spell.description;
    }


    public void ReplaceSlot(int idx)
    {       
        if (idx > PlayerSettings.deck.spells.Count || selected_spell_idx == -1)
            return;
        else if(idx == PlayerSettings.deck.spells.Count)
        {
            //Debug.Log("Hechizo " + selected_spell_idx + " a slot " + idx);
            PlayerSettings.deck.AddSpell(spells[selected_spell_idx]);            
        }
        else
        {
            PlayerSettings.deck.spells[idx] = spells[selected_spell_idx];
        }
        spellDeckslot_panels[idx].GetComponentInChildren<Image>().sprite = PlayerSettings.deck.spells[idx].thumbnail;
    }



}
