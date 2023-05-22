using ExportPackage.Runtime.Scripts.Core;

namespace CodeFramework
{
    public interface IEntity
    {
        string Id { get; }

        void Init(IHub<IService> serviceHub);
        
        void Release();
    }
}