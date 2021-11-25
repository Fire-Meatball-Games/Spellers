using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tweening
{
    public class LinearSlideEffect : IUIEffect
    {
        private readonly RectTransform rectTransform;
        private readonly float time;
        private readonly Vector2 direction;
        private readonly bool slideIn;

        public LinearSlideEffect(RectTransform rectTransform, Vector2 direction, bool slideIn, float time)
        {
            this.rectTransform = rectTransform;
            this.time = time;
            this.direction = direction;
            this.slideIn = slideIn;
        }

        public IEnumerator Execute()
        {
            var current_time = 0f;
            var delta = 1f / time;
            var screensize = new Vector2(Screen.width, Screen.height);
            var displacement = screensize * direction;

            if(slideIn)
                rectTransform.anchoredPosition = displacement;

            while (rectTransform.anchoredPosition.x != 0)
            {
                current_time += Time.deltaTime;
                var t = delta * current_time;
                var anchoredPos = Vector2.Lerp(displacement, Vector2.zero, slideIn ? t : 1 - t);
                rectTransform.anchoredPosition = anchoredPos;
                yield return null;
            }

            if (!slideIn)
                rectTransform.anchoredPosition = Vector2.zero;
        }
    }
}