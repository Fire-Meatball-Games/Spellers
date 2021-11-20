using Runtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClothingSelector : MonoBehaviour
{
    public List<Button> buttons;

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
            buttons[PlayerSettings.body].image.color = PlayerSettings.body == idx ? new Color(1f, 1f, 1f, 1f) : new Color(1f, 1f, 1f, 0.5f);
        }
    }

    void SetPlayerHat(int idx)
    {
        buttons[PlayerSettings.body].image.color = new Color(1f, 1f, 1f, 0.5f);
        PlayerSettings.body = idx;
        buttons[PlayerSettings.body].image.color = new Color(1f, 1f, 1f, 1f);
        Debug.Log("Cambiando traje del jugador a " + idx);
    }
}
