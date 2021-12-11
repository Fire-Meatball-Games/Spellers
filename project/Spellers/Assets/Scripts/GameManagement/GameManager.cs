using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Utils;
using Levels;

namespace GameManagement
{
    public class GameManager : Singleton<GameManager>
    {
        [SerializeField] private LoadingScreen loadingScreen;  
        private AsyncOperation m_loadSceneAsyncOperation; 
        private BaseGameSettings settings;

        private void Start() => LoadSceneAsync(SceneIndexes.TITLE_SCREEN);

        public void LoadSceneAsync(SceneIndexes index)
        {
            Debug.Log("Load scene " + index.ToString());
            if(index == SceneIndexes.GAME && settings == null)
            {
                Debug.LogWarning("Error: No se puede comenzar una partida sin una configuración de partida.");
                return;
            }

            int build_idx = (int)index;
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

        public void SetSettings(BaseGameSettings settings)
        {
            if(settings != null)
                this.settings = settings;
        }

        public void RemoveSettings()
        {
            settings = null;
        }

        public BaseGameSettings GetSettings() => settings;

        

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

        private void Initialize()
        {

        }
    }   
}

