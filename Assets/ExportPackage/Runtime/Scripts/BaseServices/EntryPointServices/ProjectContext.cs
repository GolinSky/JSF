using System.Collections.Generic;
using CodeFramework.Runtime.BaseServices;


namespace CodeFramework
{
    public abstract class ProjectContext : IContext<IService>
    {
        protected IGameService GameService { get; }
        public abstract List<IService> LoadContext();

        protected ProjectContext(IGameService gameService)
        {
            GameService = gameService;
        }
    }
}