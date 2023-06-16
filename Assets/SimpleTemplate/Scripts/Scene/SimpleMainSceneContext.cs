using System.Collections.Generic;
using CodeFramework.Runtime;
using CodeFramework.Runtime.BaseServices;
using CodeFramework.Runtime.Factory;
using CodeFramework.Runtime.View;
using CodeFramework.Test;

namespace CodeFramework.SimpleTemplate.Scene
{
    public class SimpleMainSceneContext:SceneContext
    {
        public override List<Controller> Data { get; }
        public override List<Controller> LoadContext()
        {
            return new List<Controller>
            {
                { Construct<SimpleController>() }
            };
        }

        public SimpleMainSceneContext(IFactory<ViewBinding, Controller> viewFactory) : base(viewFactory)
        {
            
        }

        private Controller Construct<TController>() where TController:Controller, new()
        {
            var controller = new TController();
            ViewFactory.Construct(controller);// need to rebuild this view case
            return controller;
        }
    }
}