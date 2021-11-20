using Runtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClothingSelector : MonoBehaviour
{
    public List<Button> buttons;
    public int[] body_idxs;
    private int last_selected = 0;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < buttons.Count; i++)
        {
            int idx = i;
            buttons[idx].onClick.AddListener(() => SetPlayerBody(idx));
        }
    }
    private void OnEnable()
    {
        for (int i = 0; i < buttons.Count; i++)
        {
            int idx = i;
            buttons[PlayerSettings.body].image.color = PlayerSettings.body == idx ? new Color(1f, 1f, 1f, 1f) : new Color(1f, 1f, 1f, 0.5f);
        }
    }

    void SetPlayerBody(int idx)
    {
        buttons[last_selected].image.color = new Color(1f, 1f, 1f, 0.5f);
        PlayerSettings.body = body_idxs[idx];
        last_selected = idx;
        buttons[last_selected].image.color = new Color(1f, 1f, 1f, 1f);
    }
}
