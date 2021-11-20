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
        private SpriteResolver body_resolver = default;
        [SerializeField]
        private SpriteResolver la_resolver = default;
        [SerializeField]
        private SpriteResolver ra_resolver = default;
        [SerializeField]
        private SpriteResolver ll_resolver = default;
        [SerializeField]
        private SpriteResolver rl_resolver = default;

        [SerializeField]
        public string hat_category = default;
        [SerializeField]
        public string body_category = default;
        [SerializeField]
        public string la_category = default;
        [SerializeField]
        public string ra_category = default;
        [SerializeField]
        public string ll_category = default;
        [SerializeField]
        public string lr_category = default;

        private SpriteLibraryAsset LibraryAsset => spriteLibrary.spriteLibraryAsset;

        // Start is called before the first frame update
        void Start()
        {
            SetHat(PlayerSettings.hat);
            SetBody(PlayerSettings.body);
            SetLA(PlayerSettings.body);
            SetRA(PlayerSettings.body);
            SetLL(PlayerSettings.body);
            SetRL(PlayerSettings.body);
        }

        private void SetHat(int idx)
        {
            string[] labels = LibraryAsset.GetCategoryLabelNames(hat_category).ToArray();
            int index = Mathf.Clamp(idx, 0, labels.Length - 1);
            string label = labels[index];
            hat_resolver.SetCategoryAndLabel(hat_category, label);
        }

        private void SetBody(int idx)
        {
            string[] labels = LibraryAsset.GetCategoryLabelNames(body_category).ToArray();
            int index = Mathf.Clamp(idx, 0, labels.Length - 1);
            string label = labels[index];
            body_resolver.SetCategoryAndLabel(body_category, label);
        }

        private void SetLA(int idx)
        {
            string[] labels = LibraryAsset.GetCategoryLabelNames(la_category).ToArray();
            int index = Mathf.Clamp(idx, 0, labels.Length - 1);
            string label = labels[index];
            la_resolver.SetCategoryAndLabel(la_category, label);
        }
        private void SetRA(int idx)
        {
            string[] labels = LibraryAsset.GetCategoryLabelNames(ra_category).ToArray();
            int index = Mathf.Clamp(idx, 0, labels.Length - 1);
            string label = labels[index];
            ra_resolver.SetCategoryAndLabel(ra_category, label);
        }

        private void SetLL(int idx)
        {
            string[] labels = LibraryAsset.GetCategoryLabelNames(ll_category).ToArray();
            int index = Mathf.Clamp(idx, 0, labels.Length - 1);
            string label = labels[index];
            ll_resolver.SetCategoryAndLabel(ll_category, label);
        }

        private void SetRL(int idx)
        {
            string[] labels = LibraryAsset.GetCategoryLabelNames(lr_category).ToArray();
            int index = Mathf.Clamp(idx, 0, labels.Length - 1);
            string label = labels[index];
            rl_resolver.SetCategoryAndLabel(lr_category, label);
        }

    }

}