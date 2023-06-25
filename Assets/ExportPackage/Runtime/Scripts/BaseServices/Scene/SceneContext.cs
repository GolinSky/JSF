using System;
using System.Collections.Generic;

namespace CodeFramework.Runtime.BaseServices
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
            var controller = Activator.CreateInstance(typeof(TController), GameService);
            return (Controller)controller;
        }

    }
}