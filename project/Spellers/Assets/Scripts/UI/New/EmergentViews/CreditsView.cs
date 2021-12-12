using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Tweening;
using PlayerManagement;

namespace UIManagement
{
    
    public class CreditsView : EmergentView
    {
        [SerializeField] private Button btn_logo;
        [SerializeField] private RectTransform secret_panel;
        [SerializeField] private Button btn_yes;
        [SerializeField] private Button btn_no;


        private int clicks;
        public override void Init()
        {
            base.Init();
            btn_logo.onClick.AddListener(AddClick);
            btn_yes.onClick.AddListener(() => StartCoroutine(HideSecretCR()));
            btn_no.onClick.AddListener(() => StartCoroutine(HideSecretCR()));
            btn_yes.onClick.AddListener(() => Player.instance.LastLevelUnlocked = 15);           
        }

        private void AddClick()
        {
            clicks++;
            if(clicks == 10)
            {
                StartCoroutine(ShowSecretCR());
            }
        }

        private IEnumerator ShowSecretCR()
        {
            secret_panel.localScale = Vector3.zero;
            int ticks = 10;
            float delta = 1f / ticks;
            for (int i = 0; i < ticks; i++)
            {
                secret_panel.localScale = new Vector3((i + 1) * delta, (i + 1) * delta, 1);
                yield return new WaitForFixedUpdate();
            }
            btn_no.interactable = true;
            btn_no.interactable = true;
            clicks = 0;
        }

        private IEnumerator HideSecretCR()
        {
            btn_no.interactable = false;
            btn_no.interactable = false;
            secret_panel.localScale = Vector3.one;
            int ticks = 10;
            float delta = 1f / ticks;
            for (int i = 0; i < ticks; i++)
            {
                secret_panel.localScale = new Vector3(1f - (i + 1) * delta, 1f - (i + 1) * delta, 1);
                yield return new WaitForFixedUpdate();
            }
        }

        public override void Show()
        {
            base.Show();
            Debug.Log("EEEE");
        }
    }
}
