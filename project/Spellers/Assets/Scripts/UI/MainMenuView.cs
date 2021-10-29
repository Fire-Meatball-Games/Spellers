using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UIManagement
{
    public class MainMenuView : View
    {
        [SerializeField] private Button btn_personalizar;
        [SerializeField] private Button btn_un_jugador;
        [SerializeField] private Button btn_multijugador;
        [SerializeField] private Button btn_opciones;
        

        public override void Init()
        {
            btn_personalizar.onClick.AddListener(() => ViewManager.Show<ColectionView>());
            btn_un_jugador.onClick.AddListener(() => ViewManager.Show<PlayModeView>());
            btn_multijugador.onClick.AddListener(() => ViewManager.Show<CreditsView>());
            btn_opciones.onClick.AddListener(() => ViewManager.Show<SettingsView>());            
        }
    }

}