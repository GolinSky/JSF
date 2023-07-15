using System;
using System.Collections.Generic;
using CodeFramework.Runtime.Controllers;
using CodeFramework.Runtime.Controllers.BaseServices;
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
    }
}