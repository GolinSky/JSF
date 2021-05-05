using Core.BaseServices.SceneService.Model;
using Core.Utils.Scene;
using EventHandlerUtils;
using UnityEngine;
using UnityEngine.SceneManagement;
using Application = UnityEngine.Application;
using SceneManager = UnityEngine.SceneManagement.SceneManager;

namespace Core.BaseServices.SceneService.Service
{
    public class SceneService
    {
        public const SceneType EntryScene = SceneType.Loading;
        private static LevelModel LevelModel;
        public static Handler<SceneType> SceneLoadedHandler { get; } = new Handler<SceneType>();
        public static Handler<SceneType> SceneUnloadedHandler { get; } = new Handler<SceneType>();
        public static SceneType TargetLevel { get; private set; }

        

        [RuntimeInitializeOnLoadMethod]
        public static void Init()
        {
            return;//todo: create scene model 
            LevelModel = ModelService.Service.ModelService.GetModel<LevelModel>();
            SceneManager.sceneUnloaded += HandleUnloadedScene;
            if (Application.isEditor)
            {
                var currentSceneType = LevelModel.GetTypeByName(SceneTools.ActiveScene.path);
                if (currentSceneType != SceneType.Loading)
                {
                    LoadScene(currentSceneType);
                }
                else
                {
                    LoadScene(EntryScene);
                }
            }
            else
            {
                LoadScene(EntryScene);
            }
        }

        private static void HandleUnloadedScene(Scene scene)
        {
            SceneType sceneType = LevelModel.GetTypeByName(scene.path);
            SceneUnloadedHandler?.Invoke(sceneType);
        }

        #region LoadApi

        public static void LoadEntry()
        {
            SceneTools.LoadScene(LevelModel.GetByType(EntryScene));
        }

        public static void Restart()
        {
            TargetLevel = LevelModel.GetTypeByName(SceneTools.ActiveScene.path);
            SceneTools.LoadScene(LevelModel.GetByType(SceneType.Loading));
        }

        public static void LoadScene(SceneType sceneType)
        {
            TargetLevel = sceneType;
            SceneLoadedHandler?.Invoke(sceneType);
            SceneTools.LoadScene(LevelModel.GetByType(SceneType.Loading));
        }

        public static AsyncOperation LoadSceneAsync()
        {
            return SceneTools.LoadSceneAsync(LevelModel.GetByType(TargetLevel));
        }

        #endregion
    }

    public enum SceneType
    {
        Unset = -1,
        Loading = 0,
    }
}