using System.Collections.Generic;
using CodeFramework.Runtime.BaseServices;
using ExportPackage.Runtime.Scripts.Core;

namespace CodeFramework.SimpleTemplate.Scene
{
    public sealed class SimpleSceneMap : SceneMap<SimpleSceneName>
    {
        protected override SimpleSceneName DefaultSceneKey => SimpleSceneName.Menu;
        protected override string ModelPath => "SimpleSceneModel";
        protected override ProjectContext ProjectContext { get; }

        protected override Dictionary<SimpleSceneName, SceneContext> SceneContexts =>
            new Dictionary<SimpleSceneName, SceneContext>
            {
                { SimpleSceneName.Menu, new SimpleMainSceneContext(GameService.ViewFactory) }
            };
        

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