using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;
using UnityEngine.Experimental.U2D.Animation;
using UnityEngine.U2D;

namespace Skins
{
    public class SkinDrawer : MonoBehaviour
    {
        [SerializeField] private SpriteLibrary spriteLibrary = default;

        [Header("SpriteResolvers")]        
        [SerializeField] public SpriteResolver hair_resolver = default;
        [SerializeField] public SpriteResolver hat_resolver = default;
        [SerializeField] public SpriteResolver face_resolver = default;
        [SerializeField] public SpriteResolver right_eye_resolver = default;
        [SerializeField] public SpriteResolver left_eye_resolver = default;
        [SerializeField] public SpriteResolver nose_resolver = default;
        [SerializeField] public SpriteResolver mouth_resolver = default;
        [SerializeField] public SpriteResolver coat_resolver = default;
        [SerializeField] public SpriteResolver body_resolver = default;
        [SerializeField] public SpriteResolver la_resolver = default;
        [SerializeField] public SpriteResolver ra_resolver = default;
        [SerializeField] public SpriteResolver ll_resolver = default;
        [SerializeField] public SpriteResolver rl_resolver = default;

        public void SwapSprite(SpriteResolver resolver, Sprite sprite)
        {
            if(sprite == null)
            {
                resolver.gameObject.SetActive(false);
                return;

            }
            else
            {
                resolver.gameObject.SetActive(true);
            }
            string category = resolver.GetCategory();
            string referenceLabel = resolver.GetLabel();
            Sprite referenceSprite = spriteLibrary.GetSprite(category, referenceLabel);
            SpriteBone[] bones = referenceSprite.GetBones();
            NativeArray<Matrix4x4> poses = referenceSprite.GetBindPoses();
            sprite.SetBones(bones);
            sprite.SetBindPoses(poses);

            const string customLabel = "customskin";
            spriteLibrary.AddOverride(sprite, category, customLabel);
            resolver.SetCategoryAndLabel(category, customLabel);
        }
    }
}
