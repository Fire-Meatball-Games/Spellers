using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UIManagement
{
    public class JoinView : View
    {
        [SerializeField] private Button login_btn;
        [SerializeField] private Button register_btn;
        [SerializeField] private Button playwithoutAccount_btn;
        
        public override void Init()
        {
            login_btn.onClick.AddListener(() => ViewManager.Show<LoginView>());
            register_btn.onClick.AddListener(() => ViewManager.Show<RegisterView>());
            playwithoutAccount_btn.onClick.AddListener(() => ViewManager.Show<PlayWithoutAccountView>());
        }
    }
}
