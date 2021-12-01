using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Skins;

namespace UIManagement
{
    public class SkinCollectionGUI : MonoBehaviour
    {
        [SerializeField] private GameObject cardList_prefab;
        [SerializeField] private GameObject cardView_prefab;
        [SerializeField] private RectTransform display;
        private CardSection section;

        public void Init()
        {
            List<BasicSkinPart> skins = BasicSkinPart.GetAllSkinPartsOfType(BasicSkinPart.TypePart.hat);
            AddCardSection("Sombreros", skins);
        }

        private void AddCardSection(string title, List<BasicSkinPart> skins)
        {
            section = Instantiate(cardList_prefab, display).GetComponent<CardSection>();
            section.SetLayout(title, GetCardViewList(skins));            
        }

        private List<CardView> GetCardViewList(List<BasicSkinPart> skins)
        {
            List<CardView> cards = new List<CardView>();
            foreach (var skin in skins)
            {
                cards.Add(GenerateCardView(skin));                
            }
            return cards;
        }

        private SkinCardView GenerateCardView(BasicSkinPart skin)
        {
            SkinCardView card = Instantiate(cardView_prefab).GetComponent<SkinCardView>(); 
            card.SetUp(skin, true);
            return card;
        }



    }    
}
