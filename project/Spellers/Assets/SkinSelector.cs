using Runtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkinSelector : MonoBehaviour
{
    public List<Button> buttons;
    public int[] hats_idxs;
    private int last_selected = 0;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < buttons.Count; i++)
        {
            int idx = i;
            buttons[idx].onClick.AddListener(() => SetPlayerHat(idx));            
        }
    }
    private void OnEnable()
    {
        for (int i = 0; i < buttons.Count; i++)
        {
            int idx = i;
            buttons[PlayerSettings.hat].image.color = PlayerSettings.hat == idx ? new Color(0.945f, 0.549f, 0.552f, 1f) : new Color(0.945f, 0.549f, 0.552f, 0.5f);
        }
    }

    void SetPlayerHat(int idx)
    {
        buttons[last_selected].image.color = new Color(0.945f, 0.549f, 0.552f, 0.5f);
        PlayerSettings.hat = hats_idxs[idx];
        last_selected = idx;
        buttons[last_selected].image.color = new Color(0.945f, 0.549f, 0.552f, 1f);
    }
}
