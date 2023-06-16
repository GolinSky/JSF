
using System.Collections.Generic;
using CodeFramework.Runtime.Factory;
using CodeFramework.Runtime.View;

namespace CodeFramework.Runtime.BaseServices
{
    public abstract class SceneContext:IContext<Controller>
    {
        protected IFactory<ViewBinding, Controller> ViewFactory { get; }
        public abstract List<Controller> Data { get; }
        public abstract List<Controller> LoadContext();

        protected SceneContext(IFactory<ViewBinding, Controller> viewFactory)
        {
            ViewFactory = viewFactory;
        }
        
    }
}