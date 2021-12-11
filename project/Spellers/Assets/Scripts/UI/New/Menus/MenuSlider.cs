using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace UIManagement
{
    public class MenuSlider : MonoBehaviour
    {
        [SerializeField] private RectTransform ViewLayout;

        [Header("Menus")]
        [SerializeField] private List<MenuView> views;
        [SerializeField] private int init_view;

        [Header("Animation")] 
        [Range(0f, 2f)]
        [SerializeField] private float slide_time;

        private int current_view;
        private bool isSlideDisplay;

        public void SetUp()
        {
            current_view = init_view;
            DisableSlideLayout();
        }


        // Coloca las pantallas en fila con la vista actual en el centro
        private void EnableSlideLayout()
        {
            var layout_size = new Vector2(ScreenSettings.WIDTH, 0);
            for (int i = 0; i < views.Count; i++)
            {
                views[i].Show();
                int displacement = i - current_view;
                views[i].layout.anchoredPosition = layout_size * displacement;
            }
            isSlideDisplay = true;
        }

        // Coloca las pantallas en la misma posici�n
        private void DisableSlideLayout()
        {
            for (int i = 0; i < views.Count; i++)
            {
                views[i].layout.anchoredPosition = Vector2.zero;
                if (i != current_view)
                    views[i].Hide();
                else
                    views[i].Show();

            }
            isSlideDisplay = false;
        }

        public void ShowLayout(int idx)
        {
            if (idx == current_view || idx >= views.Count) return;

            if (!isSlideDisplay)
                EnableSlideLayout();

            current_view = idx;
            StopAllCoroutines();
            IEnumerator slide = SlideView(idx);
            StartCoroutine(slide);
        }


        private IEnumerator SlideView(int dst)
        {            

            var current_time = 0f;
            var delta = 1f / slide_time;
            var target_pos = -views[dst].layout.anchoredPosition;
            var current_pos = ViewLayout.anchoredPosition;
            while (ViewLayout.anchoredPosition != target_pos)
            {
                current_time += Time.deltaTime;
                var t = delta * current_time;
                var pos = QLerp(current_pos, target_pos, t);
                ViewLayout.anchoredPosition = pos;
                yield return null;
            }            
            DisableSlideLayout();
            ViewLayout.anchoredPosition = Vector3.zero;

        }

        private Vector2 QLerp(Vector2 a, Vector2 b, float t)
        {
            Vector2 l = Vector2.Lerp(a, b, t);
            Vector2 a1 = Vector2.Lerp(a, l, t);
            Vector2 a2 = Vector2.Lerp(l, b, t);
            return Vector2.Lerp(a1, a2, t);
        }

        
    }

}