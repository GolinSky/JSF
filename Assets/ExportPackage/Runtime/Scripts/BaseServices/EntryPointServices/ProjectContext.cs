using System.Collections.Generic;


namespace CodeFramework
{
    public abstract class ProjectContext : IContext<IService>
    {
        public abstract List<IService> Data { get; }
        public abstract List<IService> LoadContext();
    }
}