using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Tweening;

namespace UIManagement
{
    public class MenuTab : MonoBehaviour
    {
        [Header("Botones")]
        [SerializeField] private List<Button> tab_buttons;
        [SerializeField] private MenuSlider m_slider;
        [Header("Animation")]
        [Range(1f, 2f)]
        [SerializeField] private float selected_size;
        [SerializeField] private float time;
        [SerializeField] private Color unselected_color;
        [SerializeField] private Color selected_color;

        private int selected_button;

        private void Awake()
        {
            selected_button = 2;
            SetUpTabButtons();            
        }

        private void SetUpTabButtons()
        {
            for (int i = 0; i < tab_buttons.Count; i++)
            {
                int idx = i;
                tab_buttons[idx].onClick.AddListener(() => OnSelectTabButton(idx));
                if (idx == selected_button)
                {
                    tab_buttons[idx].GetComponent<LayoutElement>().flexibleWidth = 1.5f;
                    tab_buttons[idx].GetComponent<Image>().color = selected_color;
                }
                else
                {
                    tab_buttons[idx].GetComponent<LayoutElement>().flexibleWidth = 1f;
                    tab_buttons[idx].GetComponent<Image>().color = unselected_color;
                }
                    

            }
        }

        private void OnSelectTabButton(int idx)
        {
            m_slider.ShowLayout(idx);
            StartCoroutine(WideButton(idx));
            selected_button = idx;
        }

        private IEnumerator WideButton(int idx)
        {
            var current_time = 0f;
            var delta = 1f / time;
            var current_element = tab_buttons[selected_button].GetComponent<LayoutElement>();
            var target_element = tab_buttons[idx].GetComponent<LayoutElement>();
            var current_img = tab_buttons[selected_button].GetComponent<Image>();
            var target_img = tab_buttons[idx].GetComponent<Image>();

            while (target_element.flexibleWidth != selected_size)
            {
                current_time += Time.deltaTime;
                var t = delta * current_time;
                current_element.flexibleWidth = Extensions.SmoothLerp(selected_size, 1f, t);
                target_element.flexibleWidth = Extensions.SmoothLerp(1f, selected_size, t);
                current_img.color = Extensions.SmoothLerp(selected_color, unselected_color, t);
                target_img.color = Extensions.SmoothLerp(unselected_color, selected_color, t);
                yield return null;
            }            
        }

    }

}