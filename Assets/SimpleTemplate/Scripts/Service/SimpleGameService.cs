using CodeFramework.Runtime;
using CodeFramework.Runtime.BaseServices;
using CodeFramework.Runtime.Factory;
using CodeFramework.Runtime.View;
using CodeFramework.SimpleTemplate.Scene;

namespace CodeFramework
{
    public sealed class SimpleGameService : GameService
    {
        protected override IRepository<string> Repository { get; }
        protected override IFactory<ViewBinding, Controller> ViewFactory { get; }
        protected override BehaviourMap SceneMap { get; }

        public SimpleGameService()
        {
            Repository = new ResourceRepository();
            ViewFactory = new ViewFactory(Repository);
            SceneMap = new SimpleSceneMap(Repository);
        }
        protected override void OnStart()
        {
            
            //check scene - load scene game service  - todo 
        }

        protected override void OnBeforeStart()
        {
            
        }
    }
}
