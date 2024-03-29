﻿using System.Collections.Generic;
using CodeFramework.Runtime.Controllers.Factory;
using CodeFramework.Runtime.Controllers.View;
using UnityEngine.SceneManagement;

namespace CodeFramework.Runtime.Controllers.BaseServices
{
    public abstract class BehaviourMap
    {
        public abstract void Load();
    }

    public interface IGameFactory
    {
        void AddController<TController>() where TController : Controller;
        void RemoveController(Controller controller);
    }
    public abstract class SceneMap<TSceneKey>:BehaviourMap, IGameFactory// impl idisposable
    {
        protected List<Controller> ContextData { get; private set; }
        protected List<ViewBinding> ViewBindings { get; private set; }

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
            SceneModel = GameService.Repository.Load<SceneModel<TSceneKey>>(ModelPath);//not use repository here - use factory - hide repository in other interface
            SceneService = new SceneService<TSceneKey>(SceneModel);
            SceneService.OnSceneLoad += OnLoadScene;
            SceneService.OnBeforeSceneLoad += ClearData;
        }

        protected virtual void ClearData(TSceneKey sceneKey)
        {
            if (ContextData != null)
            {
                foreach (var viewBinding in ViewBindings)
                {
                    viewBinding.Release();
                }
                
                foreach (var controller in ContextData)
                {
                    controller.Release();
                }
                ContextData.Clear();
                ViewBindings.Clear();
            }
        }


        protected virtual void OnLoadScene(TSceneKey key, LoadSceneMode loadSceneMode)
        {
            if (SceneContexts.TryGetValue(key, out var context))
            {
                ContextData = context.LoadContext();
                ViewBindings = new List<ViewBinding>();
                foreach (var controller in ContextData)
                {
                    InitController(controller);
                }
            }
        }

        public sealed override void Load()
        {
            OnProjectContextLoaded(ProjectContext.LoadContext());
            SceneService.LoadScene(DefaultSceneKey);
        }


        public void AddController<TController>() where TController:Controller
        {
            var controller = new ControllerFactory<TController>().Construct(GameService);
            InitController(controller);
        }

        public void RemoveController(Controller controller)
        {
            if (controller.HasView)
            {
                ViewBinding target = default;
                foreach (var viewBinding in ViewBindings) //use for instead
                {
                    if (viewBinding.Controller == controller)
                    {
                        viewBinding.Release();
                        target = viewBinding;
                    }
                }

                if (target != null)
                {
                    ViewBindings.Remove(target);
                }
            }
          
            controller.Release();
            ContextData.Remove(controller);
        }

        protected void InitController(Controller controller)
        {
            //todo: make some context - move there service hub and all factory - add gamecontext to gameservice
            controller
                .Init(this)
                .Init(ServiceHub);//refactor
            if (controller.HasView)
            {
                var binding = GameService.ViewFactory.Construct(controller);
                if (binding != null)
                {
                    ViewBindings.Add(binding);
                }
            }
      
        }
        protected abstract void OnProjectContextLoaded(List<IService> services);

    }
}