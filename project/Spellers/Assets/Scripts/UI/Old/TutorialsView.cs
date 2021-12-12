using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UIManagement
{
    public class TutorialsView : EmergentView
    {
        public List<TutorialDisplay> tutorialDisplays;
        public List<Button> display_buttons;
        int current_tutorial;

        public override void Init()
        {
            base.Init();
            int count = Mathf.Min(tutorialDisplays.Count, display_buttons.Count);
            for (int i = 0; i < count; i++)
            {                
                int idx = i;
                display_buttons[idx].interactable = true;
                tutorialDisplays[idx].SetUp();
                display_buttons[idx].onClick.AddListener(() => LoadTutorial(idx));
            }
        }     
        
        private void LoadTutorial(int idx)
        {
            tutorialDisplays[current_tutorial].Hide();
            display_buttons[current_tutorial].interactable = true;

            current_tutorial = idx;

            display_buttons[idx].interactable = false;
            tutorialDisplays[idx].Show();            
        }
    }

    [System.Serializable]
    public class TutorialDisplay
    {
        public GameObject layout;
        public List<GameObject> pages;
        public GameObject btn_layout;
        public List<Button> page_buttons;
        public int currentPage;

        public void SetUp()
        {
            currentPage = 0;
            int count = Mathf.Min(pages.Count, page_buttons.Count);
            for (int i = 0; i < count; i++)
            {
                int idx = i;
                page_buttons[idx].onClick.AddListener(()=>LoadPage(idx)); 
            }
        }

        public void Show()
        {
            layout.SetActive(true);
            btn_layout.SetActive(true);
            LoadPage(0);
        }

        public void Hide()
        {
            layout.SetActive(false);
            btn_layout.SetActive(false);
            pages[currentPage].SetActive(false);
            currentPage = 0;
        }

        private void LoadPage(int idx)
        {
            pages[currentPage].SetActive(false);
            currentPage = idx;
            pages[idx].SetActive(true);
        }
    }

}
