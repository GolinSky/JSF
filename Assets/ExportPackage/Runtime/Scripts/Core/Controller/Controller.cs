using ExportPackage.Runtime.Scripts.Core;

namespace CodeFramework.Runtime
{
    public interface IController : IViewController, IEntity
    {
    }
    public abstract class Controller: IController
    {
        protected IHub<IService> ServiceHub { get; private set; }
        public void Init(IHub<IService> serviceHub)
        {
            ServiceHub = serviceHub;
        }

        public virtual string Id => GetType().Name;

        public void Release()
        {
            OnRelease();
        }

        protected virtual void OnRelease(){}
    }
}

