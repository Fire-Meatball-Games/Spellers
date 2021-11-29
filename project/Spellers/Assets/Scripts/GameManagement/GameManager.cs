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

        public void LoadSceneAsync(SceneIndexes index)
        {
            int build_idx = (int)index;
            Debug.Log("Cargando escena " + build_idx);
            m_loadSceneAsyncOperation = SceneManager.LoadSceneAsync(build_idx, LoadSceneMode.Additive);
            StartCoroutine(GetSceneLoadProgress());
        }

        public void UnloadScene(SceneIndexes index)
        {
            int build_idx = (int)index;
            SceneManager.UnloadSceneAsync(build_idx);
        }
        public override void Init() 
        {
            base.Init();
        }

        public void Start() => LoadSceneAsync(SceneIndexes.TITLE_SCREEN);

        //private void Start() => LoadScene(SceneIndexes.MAIN_MENU);
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

