using System.Collections.Generic;
using CodeFramework.Runtime;
using CodeFramework.Runtime.BaseServices;
using ExportPackage.Runtime.Scripts.Core;
using UnityEngine.SceneManagement;

namespace CodeFramework.SimpleTemplate.Scene
{
    public sealed class SimpleSceneMap : SceneMap<SimpleSceneName>
    {
        private List<Controller> contextData;
        protected override SimpleSceneName DefaultSceneKey => SimpleSceneName.Menu;
        protected override string ModelPath => "SimpleSceneModel";
        protected override ProjectContext ProjectContext { get; }

        protected override Dictionary<SimpleSceneName, SceneContext> SceneContexts =>
            new Dictionary<SimpleSceneName, SceneContext>
            {
                { SimpleSceneName.Menu, new SimpleMainSceneContext(GameService.ViewFactory) }
            };

        protected sealed override IHub<IService> ServiceHub { get;  set; }


        protected override void OnSceneUnload(SimpleSceneName key)
        {
            if (contextData != null)// todo:check if need key - dict 
            {
                foreach (var controller in contextData)
                {
                    controller.Release();
                }
            }
        }

        protected override void OnLoadScene(SimpleSceneName key, LoadSceneMode loadSceneMode)
        {
            if (SceneContexts.TryGetValue(key, out var context))
            {
                contextData = context.LoadContext();

                foreach (var controller in contextData)
                {
                    controller.Init(ServiceHub);
                }
            }
        }
        

        protected override void OnProjectContextLoaded(List<IService> services)
        {
            ServiceHub = new ServiceHub(services);
        }


        public SimpleSceneMap(IGameService gameService) : base(gameService)
        {
            ProjectContext = new SimpleProjectContext();
        }

    }
}