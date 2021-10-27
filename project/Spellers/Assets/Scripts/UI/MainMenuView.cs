using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UIManagement
{
    public class MainMenuView : View
    {
        [SerializeField] private Button btn_jugar;
        [SerializeField] private Button btn_coleccion;
        [SerializeField] private Button btn_opciones;
        [SerializeField] private Button btn_creditos;
        [SerializeField] private Button btn_atras;

        public override void Init()
        {
            btn_jugar.onClick.AddListener(() => ViewManager.Show<PlayModeView>());
            btn_coleccion.onClick.AddListener(() => ViewManager.Show<ColectionView>());
            btn_opciones.onClick.AddListener(() => ViewManager.Show<SettingsView>());
            btn_creditos.onClick.AddListener(() => ViewManager.Show<CreditsView>());
            btn_atras.onClick.AddListener(() => Application.Quit());
        }
    }

}