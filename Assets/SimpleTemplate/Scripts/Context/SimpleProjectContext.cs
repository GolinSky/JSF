using System.Collections.Generic;
using CodeFramework.Runtime.Controllers.BaseServices;


namespace CodeFramework
{
    public class SimpleProjectContext:ProjectContext
    {
        public override List<IService> LoadContext()
        {
            return new List<IService>();
        }

        public SimpleProjectContext(IGameService gameService) : base(gameService)
        {
        }
    }
}