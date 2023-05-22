using System.Collections.Generic;
using CodeFramework.Runtime;
using CodeFramework.Runtime.BaseServices;

namespace CodeFramework.SimpleTemplate.Scene
{
    public class SimpleMainSceneContext:SceneContext
    {
        public override List<Controller> Data { get; }
        public override List<Controller> LoadContext()
        {
            return new List<Controller>();
        }
    }
}