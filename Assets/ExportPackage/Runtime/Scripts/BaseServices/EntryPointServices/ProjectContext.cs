using System.Collections.Generic;
using ExportPackage.Runtime.Scripts.Core;

namespace CodeFramework
{
    public abstract class ProjectContext : IContext<IService>
    {
        public abstract List<IService> Data { get; }
        public abstract List<IService> LoadContext();
    }
}