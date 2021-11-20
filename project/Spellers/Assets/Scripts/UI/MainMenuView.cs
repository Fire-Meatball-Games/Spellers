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

        public int inic = 1;

        public void Update()
        {
            GetComponent<Animator>().SetInteger("Inicializar", inic);
        }

        public override void Init()
        {
            Animator animacion = GetComponent<Animator>();

            btn_personalizar.onClick.AddListener(() => inic = 2);
            btn_personalizar.onClick.AddListener(() => animacion.SetBool("Salir", true));
            btn_personalizar.onClick.AddListener(() => Invoke("personalizar", 1.0f));

            btn_un_jugador.onClick.AddListener(() => inic = 0);
            btn_un_jugador.onClick.AddListener(() => animacion.SetBool("Salir", true));
            btn_un_jugador.onClick.AddListener(() => Invoke("unJugador", 1.0f));

            btn_multijugador.onClick.AddListener(() => inic = 0);
            btn_multijugador.onClick.AddListener(() => animacion.SetBool("Salir", true));
            btn_multijugador.onClick.AddListener(() => Invoke("multijugador", 1.0f));

            btn_opciones.onClick.AddListener(() => inic = 1);
            btn_opciones.onClick.AddListener(() => animacion.SetBool("Salir", true));
            btn_opciones.onClick.AddListener(() => Invoke("opciones", 1.0f));
        }

        public void personalizar()
        {
            ViewManager.Show<CustomView>();
        }

        public void unJugador()
        {
            ViewManager.Show<SinglePlayerView>();
        }

        public void multijugador()
        {
            ViewManager.Show<MultiplayerView>();
        }

        public void opciones()
        {
            ViewManager.Show<SettingsView>();
        }
    }
}