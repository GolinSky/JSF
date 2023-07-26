using CodeFramework.Runtime;
using CodeFramework.Runtime.Controllers;
using CodeFramework.Runtime.Controllers.BaseServices;
using CodeFramework.Runtime.Controllers.Factory;
using CodeFramework.Runtime.Controllers.View;
using CodeFramework.SimpleTemplate.Scene;

namespace CodeFramework
{
    [EntryPoint]
    public sealed class SimpleGameService : GameService
    {
        protected override IRepository<string> Repository=> new ResourceRepository();
        protected override IFactory<ViewBinding, Controller> ViewFactory => new ViewFactory(Repository);
        protected override BehaviourMap SceneMap => new SimpleSceneMap(this);

        protected override void OnStart()
        {
            
            //check scene - load scene game service  - todo 
        }

        protected override void OnBeforeStart()
        {
            
        }
        
    }
}
