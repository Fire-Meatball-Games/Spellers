using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using TMPro;
using System;

namespace Ingame.UI
{
    public class Runestone : MonoBehaviour
    {
        public static readonly Color HIT_COLOR = new Color(0.5f, 1f, 1f);
        public static readonly Color FAIL_COLOR = new Color(0.5f, 0.5f, 0.5f);
        [SerializeField] private Button button;
        [SerializeField] private TextMeshProUGUI text;
        [SerializeField] private List<Sprite> base_sprites;
        [SerializeField] private List<Sprite> pressed_sprites;

        private char runechar;
        private event Func<char, bool> Onpress;

        private void Awake() 
        {
            int idx = UnityEngine.Random.Range(0, Mathf.Min(base_sprites.Count, pressed_sprites.Count));
            button.image.sprite = base_sprites[idx];
            var ss = button.spriteState;
            ss.pressedSprite = pressed_sprites[idx];
            button.onClick.AddListener(OnClick);
        }

        public void SetUp(char car, Func<char, bool> func)
        {
            runechar = car;
            text.text = runechar.ToString();
            Onpress += func;   
        }
 
        private void OnClick()
        {
            bool hit = Onpress.Invoke(runechar);
            button.interactable = false;
            Disable(hit);            
        }

        private void Disable(bool hit)
        {
            Debug.Log("Runestone: " + hit);
            text.color = hit ? HIT_COLOR : FAIL_COLOR;
            button.image.color = Color.white;
        }
    }

}

