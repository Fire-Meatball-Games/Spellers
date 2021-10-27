using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Utils;

namespace GameManagement
{
    public class GameManager : Singleton<GameManager>
    {
        public static void LoadScene(string scene)
        {
            SceneManager.LoadScene(scene);
        }

        public static void LoadbattleLevel()
        {

        }
    } 
}
