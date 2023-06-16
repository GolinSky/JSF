using System.Collections.Generic;
using CodeFramework.Runtime;
using CodeFramework.Runtime.BaseServices;
using CodeFramework.Runtime.Factory;
using CodeFramework.Runtime.View;
using ExportPackage.Runtime.Scripts.Core;
using UnityEngine.SceneManagement;

namespace CodeFramework.SimpleTemplate.Scene
{
    public class SimpleSceneMap : SceneMap<SimpleSceneName>
    {
        private List<Controller> contextData;
        protected override SimpleSceneName DefaultSceneKey => SimpleSceneName.Main;
        protected override string ModelPath => "SimpleSceneModel";
        protected override ProjectContext ProjectContext { get; }
        protected IFactory<ViewBinding, Controller> ViewFactory { get; private set; }

        protected override Dictionary<SimpleSceneName, SceneContext> SceneContexts =>
            new Dictionary<SimpleSceneName, SceneContext>
            {
                { SimpleSceneName.Main, new SimpleMainSceneContext(ViewFactory) }
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


        public SimpleSceneMap(IRepository<string> repository, IFactory<ViewBinding, Controller> viewFactory) : base(repository)
        {
            ProjectContext = new SimpleProjectContext();
            ViewFactory = viewFactory;
        }

    }
}