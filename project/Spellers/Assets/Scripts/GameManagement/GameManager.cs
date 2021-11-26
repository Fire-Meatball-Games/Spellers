using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Utils;

namespace GameManagement
{
    public class GameManager : Singleton<GameManager>
    {
        [SerializeField] private LoadingScreen loadingScreen;  
        private AsyncOperation m_loadSceneAsyncOperation; 

        public void LoadScene(SceneIndexes index)
        {
            Debug.Log("Cargando escena 1");
            m_loadSceneAsyncOperation = SceneManager.LoadSceneAsync((int)index, LoadSceneMode.Additive);
            StartCoroutine(GetSceneLoadProgress());
        }

        private void Start() => LoadScene(SceneIndexes.MAIN_MENU);
        private IEnumerator GetSceneLoadProgress()
        {
            loadingScreen.Show();
            while(!m_loadSceneAsyncOperation.isDone){

                var loadingProgress = m_loadSceneAsyncOperation.progress;
                loadingScreen.SetProgressBarValue(loadingProgress);
                yield return null;
            }
            loadingScreen.SetProgressBarValue(m_loadSceneAsyncOperation.progress);
            yield return new WaitForSeconds(2f);
            loadingScreen.Hide();
        }
    }   
}

