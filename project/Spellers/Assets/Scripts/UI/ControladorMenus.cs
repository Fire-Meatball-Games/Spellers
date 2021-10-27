using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UIManagement
{
    public class ControladorMenus : MonoBehaviour
    {
        ////////////////////
        //// Variables ////
        //////////////////

        public GameObject menuPrincipal;
        public GameObject menuJugar;
        public GameObject menuColeccion;
        public GameObject menuOpciones;
        public GameObject menuCreditos;

        public GameObject fuentePequeñaObj;
        public GameObject fuenteMedianaObj;
        public GameObject fuenteGrandeObj;
        Toggle fuentePequeña;
        Toggle fuenteMediana;
        Toggle fuenteGrande;

        public GameObject pantallaCompleta;

        //////////////////
        //// Metodos ////
        ////////////////

        // Start is called before the first frame update
        void Start()
        {
            menuPrincipal.SetActive(true);
            menuJugar.SetActive(false);
            menuColeccion.SetActive(false);
            menuOpciones.SetActive(false);
            menuCreditos.SetActive(false);
            fuentePequeña = fuentePequeñaObj.GetComponent<Toggle>();
            fuenteMediana = fuenteMedianaObj.GetComponent<Toggle>();
            fuenteGrande = fuenteGrandeObj.GetComponent<Toggle>();
        }

        // Update is called once per frame
        void Update()
        {
            if (Screen.fullScreen)
            {
                pantallaCompleta.SetActive(true);
            }
            else
            {
                pantallaCompleta.SetActive(false);
            }
        }

        //// Metodo para todos los Menus ////
        public void clickPantallaCompleta()
        {
            Screen.fullScreen = false;
        }

        //// Metodos para el Menu Principal ////
        public void clickJugar()
        {
            menuJugar.SetActive(true);
            menuPrincipal.SetActive(false);
        }

        public void clickColeccion()
        {
            menuColeccion.SetActive(true);
            menuPrincipal.SetActive(false);
        }

        public void clickOpciones()
        {
            menuOpciones.SetActive(true);
            menuPrincipal.SetActive(false);
        }

        public void clickCreditos()
        {
            menuCreditos.SetActive(true);
            menuPrincipal.SetActive(false);
        }

        public void clickSalir()
        {
            Debug.Log("Salir");
        }

        //// Metodo para los Menus que no sen el Principal ////
        public void clickAtras()
        {
            menuPrincipal.SetActive(true);
            menuJugar.SetActive(false);
            menuColeccion.SetActive(false);
            menuOpciones.SetActive(false);
            menuCreditos.SetActive(false);
        }
    }

}