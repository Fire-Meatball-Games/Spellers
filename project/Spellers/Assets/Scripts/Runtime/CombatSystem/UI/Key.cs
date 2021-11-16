using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using TMPro;

namespace Runtime.CombatSystem.UI
{
    public class Key : MonoBehaviour
    {
        public Button button;
        public TextMeshProUGUI text;

        public List<Sprite> base_sprites;
        public List<Sprite> pressed_sprites;

        public void SetUp(char c)
        {
            button.onClick.AddListener(OnClick);
            int idx = Random.Range(0, Mathf.Min(base_sprites.Count, pressed_sprites.Count));
            button.image.sprite = base_sprites[idx];
            var ss = button.spriteState;
            ss.pressedSprite = pressed_sprites[idx];
            text.text = c.ToString();
        }

        public void SetListener(UnityAction call)
        {
            button.onClick.AddListener(call);
        }

        private void OnClick()
        {
            button.onClick.RemoveAllListeners();
            text.color = new Color(0.5f, 1f, 1f);
            button.image.color = new Color(1f, 1f, 1f);
        }
    }

}