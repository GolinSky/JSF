using CodeFramework;

namespace ExportPackage.Runtime.Scripts.Core
{
    public interface IService:IEntity
    {
        
    }
    
    public abstract class Service:IService
    {
        protected IHub<IService> ServiceHub { get; private set; }

        public string Id => nameof(Service);

        public void Init(IHub<IService> serviceHub)
        {
            ServiceHub = serviceHub;
        }


        public void Release()
        {
            ServiceHub.Remove(this);
        }
    }
}