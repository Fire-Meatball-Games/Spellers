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

        public void UpdateSkin(Skin skin)
        {
            if(skin == null) return;
            if(skin.Hat != null) SwapSprite(hat_resolver, skin.Hat.SpriteSkin); else SwapSprite(hat_resolver, null);
            if(skin.Hair != null) SwapSprite(hair_resolver, skin.Hair.SpriteSkin); else SwapSprite(hair_resolver, null);
            if(skin.Face != null) SwapSprite(face_resolver, skin.Face.SpriteSkin); else SwapSprite(face_resolver, null);
            if(skin.Eyes != null) SwapSprite(right_eye_resolver, skin.Eyes.RightEye); else SwapSprite(right_eye_resolver, null);
            if(skin.Eyes != null) SwapSprite(left_eye_resolver, skin.Eyes.LeftEye); else SwapSprite(left_eye_resolver, null);
            if(skin.Nose != null) SwapSprite(nose_resolver, skin.Nose.SpriteSkin); else SwapSprite(nose_resolver, null);
            if(skin.Mouth != null) SwapSprite(mouth_resolver, skin.Mouth.SpriteSkin); else SwapSprite(mouth_resolver, null);
            if(skin.Coat != null) SwapSprite(coat_resolver, skin.Coat.SpriteSkin); else SwapSprite(coat_resolver, null);
            if(skin.Body != null) SwapSprite(body_resolver, skin.Body.BodySkin); else SwapSprite(body_resolver, null);
            if(skin.Body != null) SwapSprite(la_resolver, skin.Body.LeftArmSkin); else SwapSprite(la_resolver, null);
            if(skin.Body != null) SwapSprite(ra_resolver, skin.Body.RightArmSkin); else SwapSprite(ra_resolver, null);
            if(skin.Body != null) SwapSprite(ll_resolver, skin.Body.LeftLegSkin); else SwapSprite(ll_resolver, null);
            if(skin.Body != null) SwapSprite(rl_resolver, skin.Body.RightLegSkin); else SwapSprite(rl_resolver, null);

        }
    }
}
