using System;
using System.Collections.Generic;
using CodeFramework.Runtime;
using CodeFramework.Runtime.BaseServices;
using CodeFramework.Test;

namespace CodeFramework.SimpleTemplate.Scene
{
    public class SimpleMainSceneContext:SceneContext
    {
        
        public SimpleMainSceneContext(IGameService gameService) : base(gameService)
        {
        }
        public override List<Controller> LoadContext()
        {
            return new List<Controller>
            {
                { Construct<SimpleController>() }
            };
        }

        private Controller Construct<TController>() where TController:Controller
        {
            var controller = Activator.CreateInstance(typeof(TController), GameService);
            return (Controller)controller;
        }

        
    }
}