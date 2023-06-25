using System.Collections.Generic;
using CodeFramework.Runtime;
using CodeFramework.Runtime.BaseServices;
using CodeFramework.Runtime.View;
using CodeFramework.Test;

namespace CodeFramework.SimpleTemplate.Scene
{
    public class SimpleMainSceneContext:SceneContext
    {
        public override List<Controller> LoadContext()
        {
            return new List<Controller>
            {
                { Construct<SimpleController>() }
            };
        }

        private Controller Construct<TController>() where TController:Controller, new()
        {
            var controller = new TController();
            return controller;
        }
    }
}