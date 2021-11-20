using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Experimental.U2D.Animation;

namespace Runtime
{
    public class SkinDrawer : MonoBehaviour
    {

        [SerializeField]
        private SpriteLibrary spriteLibrary = default;

        [SerializeField]
        private SpriteResolver hat_resolver = default;

        [SerializeField]
        public string hat_category = default;

        private SpriteLibraryAsset LibraryAsset => spriteLibrary.spriteLibraryAsset;

        // Start is called before the first frame update
        void Start()
        {
            SetHat(PlayerSettings.hat);
        }

        private void SetHat(int idx)
        {
            string[] labels = LibraryAsset.GetCategoryLabelNames(hat_category).ToArray();
            int index = Mathf.Clamp(idx, 0, labels.Length - 1);
            string label = labels[index];
            hat_resolver.SetCategoryAndLabel(hat_category, label);
        }
    }

}