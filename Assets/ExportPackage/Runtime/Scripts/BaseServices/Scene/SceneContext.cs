using System.Collections.Generic;

namespace CodeFramework.Runtime.BaseServices
{
    public abstract class SceneContext:IContext<Controller>
    {
        public abstract List<Controller> LoadContext();
    }
}