using System.Collections.Generic;
using CodeFramework.Runtime.Controllers.Factory;

namespace CodeFramework.Runtime.Controllers.BaseServices
{
    public abstract class SceneContext:IContext<Controller>
    {
        protected IGameService GameService { get; }
        public abstract List<Controller> LoadContext();

        protected SceneContext(IGameService gameService)
        {
            GameService = gameService;
        }
        
        protected Controller Construct<TController>() where TController:Controller
        {
            return new ControllerFactory<TController>().Construct(GameService);
        }

    }
}