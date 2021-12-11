using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Skins;
using System.Linq;
using CustomEventSystem;

namespace UIManagement
{
    public class SkinCollectionGUI : MonoBehaviour
    {
        [SerializeField] private GameObject cardList_prefab;
        [SerializeField] private GameObject cardView_prefab;
        [SerializeField] private RectTransform display;

        [SerializeField] private Button face_btn;
        [SerializeField] private Button hair_btn;
        [SerializeField] private Button hat_btn;
        [SerializeField] private Button eyes_btn;
        [SerializeField] private Button nose_btn;
        [SerializeField] private Button mouth_btn;
        [SerializeField] private Button coat_btn;
        [SerializeField] private Button body_btn;
        private CardSection section;

        public void Init()
        {            
            face_btn.onClick.AddListener(()=>SetCardSection(BasicSkinPart.TypePart.face));
            hair_btn.onClick.AddListener(()=>SetCardSection(BasicSkinPart.TypePart.hair));
            hat_btn.onClick.AddListener(()=>SetCardSection(BasicSkinPart.TypePart.hat));
            eyes_btn.onClick.AddListener(()=>SetCardEyesSection());
            nose_btn.onClick.AddListener(()=>SetCardSection(BasicSkinPart.TypePart.nose));
            mouth_btn.onClick.AddListener(()=>SetCardSection(BasicSkinPart.TypePart.mouth));
            coat_btn.onClick.AddListener(()=>SetCardSection(BasicSkinPart.TypePart.coat));
            body_btn.onClick.AddListener(()=>SetCardSection());
            SetCardSection(BasicSkinPart.TypePart.face);

            Events.OnModifyPlayerSkin.Invoke();

        }

        private void AddCardSection(string title, List<SkinPart> skins)
        {
            section = Instantiate(cardList_prefab, display).GetComponent<CardSection>();
            section.SetLayout(title, GetCardViewList(skins));            
        }

        private List<CardView> GetCardViewList(List<SkinPart> skins)
        {
            List<CardView> cards = new List<CardView>();
            foreach (var skin in skins)
            {
                cards.Add(GenerateCardView(skin));                
            }
            return cards;
        }

        private SkinCardView GenerateCardView(SkinPart skin)
        {
            SkinCardView card = Instantiate(cardView_prefab).GetComponent<SkinCardView>(); 
            card.SetUp(skin, true);
            return card;
        }

        private void SetCardSection(BasicSkinPart.TypePart part)
        {
            if(section != null)
            {
                section.Clear();
                CardSection oldsection = section;
                Destroy(oldsection.gameObject);
                section = null;
            }
            
            List<SkinPart> skins = BasicSkinPart.GetAllSkinPartsOfType(part).Cast<SkinPart>().ToList();
            AddCardSection(part.ToString(), skins);
        }

        private void SetCardSection()
        {
            if(section != null)
            {
                section.Clear();
                CardSection oldsection = section;
                Destroy(oldsection.gameObject);
                section = null;
            }
            List<SkinPart> skins = CompoundSkinPart.GetAllSkinParts().Cast<SkinPart>().ToList();
            AddCardSection("Trajes", skins);
        }

        private void SetCardEyesSection()
        {
            if(section != null)
            {
                section.Clear();
                CardSection oldsection = section;
                Destroy(oldsection.gameObject);
                section = null;
            }
            List<SkinPart> skins = DoubleSkinPart.GetAllSkinParts().Cast<SkinPart>().ToList();
            AddCardSection("Ojos", skins);
        }



    }    
}
