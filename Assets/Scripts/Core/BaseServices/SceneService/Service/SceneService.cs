﻿using Core.BaseServices.SceneService.Model;
using Core.Utils.Scene;
using EventHandlerUtils;
using UnityEngine;

namespace Core.BaseServices.SceneService.Service
{
    public class SceneService
    {
        public const SceneType EntryScene = SceneType.Loading;
        private static LevelModel LevelModel;
        private static SceneType PreviousScene = SceneType.Loading;

        public static Handler<SceneType> SceneLoadedHandler { get; } = new Handler<SceneType>();
        public static Handler<SceneType> SceneUnloadedHandler { get; } = new Handler<SceneType>();
        public static SceneType TargetLevel { get; private set; }

        public static SceneType CurrentSceneType => LevelModel.GetTypeByName(SceneTools.ActiveScene.path);


        [RuntimeInitializeOnLoadMethod]
        public static void Init()
        {
            LevelModel = ModelService.Service.ModelService.GetModel<LevelModel>();

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

        public static void LoadScene(SceneType sceneType)
        {
            PreviousScene = CurrentSceneType;
            TargetLevel = sceneType;
            SceneUnloadedHandler?.Invoke(PreviousScene);
            SceneLoadedHandler?.Invoke(sceneType);
            SceneTools.LoadScene(LevelModel.GetByType(SceneType.Loading));
        }

        public static AsyncOperation LoadSceneAsync()
        {
            return SceneTools.LoadSceneAsync(LevelModel.GetByType(TargetLevel));
        }

    }

    public enum SceneType
    {
        Unset = -1,
        Loading = 0,
        Test = 1,
    }
}