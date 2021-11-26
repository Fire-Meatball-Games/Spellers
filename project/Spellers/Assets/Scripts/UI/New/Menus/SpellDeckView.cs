using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UIManagement
{
    public class SpellDeckView : MenuView
    {
        [Header("Context Menu")]
        [SerializeField] private RectTransform contextMenu_rt;
        [SerializeField] private Button info_btn;
        [SerializeField] private Button use_btn;

        [Header("Spell Collection")]
        [SerializeField] private GameObject spellGridList;
        [SerializeField] private GameObject spellCard_prefab;

        [Header("Spell Deck")]
        
        [SerializeField] private GameObject spellDeckList;




        public override void Init()
        {
            
        }
    }

}