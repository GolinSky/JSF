using System.Collections.Generic;
using ExportPackage.Runtime.Scripts.Core;

namespace CodeFramework
{
    public class SimpleProjectContext:ProjectContext
    {
        public override List<IService> Data { get; }
        public override List<IService> LoadContext()
        {
            return new List<IService>();
        }
    }
}