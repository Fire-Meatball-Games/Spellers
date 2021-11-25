using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Tweening
{
    public class ImageColorEffect : IUIEffect
    {
        private Image target;
        private Color color;
        private float time;

        public ImageColorEffect(Image target, Color color, float time)
        {
            this.target = target;
            this.color = color;
            this.time = time;
        }

        public IEnumerator Execute()
        {
            var current_time = 0f;
            var delta = 1f / time;
            var current_color = target.color;

            while(target.color != color)
            {
                current_time += Time.deltaTime;
                var t = delta * current_time;
                target.color = Color.Lerp(current_color, color, t);
                yield return null;
            }
        }
    }

}