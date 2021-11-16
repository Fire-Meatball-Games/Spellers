using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UIManagement
{
    public class ControladorMenus : MonoBehaviour
    {
        public GameObject pantallaCompleta;

        public void Awake()
        {
            //Application.targetFrameRate = 60;
        }

        public void Update()
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
    }

}