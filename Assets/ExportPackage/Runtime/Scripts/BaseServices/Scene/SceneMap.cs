﻿using System.Collections.Generic;
using ExportPackage.Runtime.Scripts.Core;
using UnityEngine.SceneManagement;

namespace CodeFramework.Runtime.BaseServices
{
    public abstract class BehaviourMap
    {
        public abstract void Load();
    }
    public abstract class SceneMap<TSceneKey>:BehaviourMap
    {
        protected List<Controller> ContextData { get; private set; }

        protected IGameService GameService { get; }
        protected abstract TSceneKey DefaultSceneKey { get; }
        protected abstract string ModelPath { get; }
        protected SceneService<TSceneKey> SceneService { get; }
        protected SceneModel<TSceneKey> SceneModel { get; }
        
        protected abstract ProjectContext ProjectContext { get; }

        protected abstract Dictionary<TSceneKey, SceneContext> SceneContexts { get; }
        
        protected IHub<IService> ServiceHub { get;  set; }

        protected SceneMap(IGameService gameService)
        {
            GameService = gameService;
            SceneModel = GameService.Repository.Load<SceneModel<TSceneKey>>(ModelPath);
            SceneService = new SceneService<TSceneKey>(SceneModel);
            SceneService.OnSceneLoad += OnLoadScene;
            SceneService.OnSceneUnLoad += OnSceneUnload;
        }

        protected virtual void OnSceneUnload(TSceneKey key)
        {
            if (ContextData != null)// todo:check if need key - dict 
            {
                foreach (var controller in ContextData)
                {
                    controller.Release();
                }
            }
        }

        protected virtual void OnLoadScene(TSceneKey key, LoadSceneMode loadSceneMode)
        {
            if (SceneContexts.TryGetValue(key, out var context))
            {
                ContextData = context.LoadContext();

                foreach (var controller in ContextData)
                {
                    controller.Init(ServiceHub);
                }
            }
        }

        public sealed override void Load()
        {
            OnProjectContextLoaded(ProjectContext.LoadContext());
            SceneService.LoadScene(DefaultSceneKey);
        }

        protected abstract void OnProjectContextLoaded(List<IService> services);

    }
}