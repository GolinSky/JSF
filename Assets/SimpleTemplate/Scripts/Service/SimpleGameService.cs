using CodeFramework.Runtime.BaseServices;
using CodeFramework.Runtime.Factory;
using CodeFramework.SimpleTemplate.Scene;

namespace CodeFramework
{
    public sealed class SimpleGameService : GameService
    {

        public SimpleGameService()
        {
            Repository = new ResourceRepository();
            ViewFactory = new ViewFactory(Repository);
            SceneMap = new SimpleSceneMap(this); //todo: need to check this approach using igameservice in ctor
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
