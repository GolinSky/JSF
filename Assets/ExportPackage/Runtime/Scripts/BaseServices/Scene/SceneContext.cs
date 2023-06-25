using System.Collections.Generic;

namespace CodeFramework.Runtime.BaseServices
{
    public abstract class SceneContext:IContext<Controller>
    {
        protected IGameService GameService { get; }
        public abstract List<Controller> LoadContext();

        public SceneContext(IGameService gameService)
        {
            GameService = gameService;
        }
    }
}