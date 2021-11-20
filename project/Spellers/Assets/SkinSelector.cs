using Runtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkinSelector : MonoBehaviour
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
            buttons[PlayerSettings.hat].image.color = PlayerSettings.hat == idx ? new Color(1f, 1f, 1f, 1f) : new Color(1f, 1f, 1f, 0.5f);
        }
    }

    void SetPlayerHat(int idx)
    {
        buttons[PlayerSettings.hat].image.color = new Color(1f, 1f, 1f, 0.5f);
        PlayerSettings.hat = idx;
        buttons[PlayerSettings.hat].image.color = new Color(1f, 1f, 1f, 1f);
        Debug.Log("Cambiando gorro del jugador a " + idx);
    }
}
