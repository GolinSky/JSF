using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace CodeFramework.Runtime.Controllers.BaseServices
{
    public class SceneService<TSceneKey>
    {
        public Action<TSceneKey, LoadSceneMode> OnSceneLoad;
        public Action<TSceneKey> OnBeforeSceneLoad;
        public Action<TSceneKey> OnSceneUnLoad;
        protected SceneModel<TSceneKey> Model { get; }
        public TSceneKey ActiveSceneName { get; private set; }
        private Scene ActiveScene => SceneManager.GetActiveScene();

        public SceneService(SceneModel<TSceneKey> model)
        {
            Model = model;
            SceneManager.sceneLoaded += OnSceneLoaded;
            SceneManager.sceneUnloaded += OnSceneUnloaded;// need to be unsubscribed
        }

        private void OnSceneUnloaded(Scene scene)
        {
            var sceneKey = Model.GetKeyByScene(scene);
            if (sceneKey != null)
            {
                OnSceneUnLoad?.Invoke(sceneKey);
            }
        }

        private void OnSceneLoaded(Scene scene, LoadSceneMode loadSceneMode)
        {
            var sceneKey = Model.GetKeyByScene(scene);
            if (sceneKey != null)
            {
                OnSceneLoad?.Invoke(sceneKey, loadSceneMode);
            }
        }

        public void LoadScene(TSceneKey key)
        {
            var refScene = Model.GetSceneReference(key);
            OnBeforeSceneLoad?.Invoke(key);
            LoadScene(refScene.ScenePath);
            ActiveSceneName = key;
        }

        private void LoadScene(string sceneName)
        {
            SceneManager.LoadScene(sceneName);
        }

        private AsyncOperation LoadSceneAsync(string sceneName)
        {
            return SceneManager.LoadSceneAsync(sceneName);
        }
    }
}