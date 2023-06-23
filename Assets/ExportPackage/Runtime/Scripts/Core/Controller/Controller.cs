namespace CodeFramework.Runtime
{
    public interface IController : IViewController, IEntity
    {
    }
    public abstract class Controller: IController
    {
        protected IHub<IService> ServiceHub { get; private set; }
        public virtual string Id => GetType().Name;

        public void Init(IHub<IService> serviceHub)
        {
            ServiceHub = serviceHub;
            OnInit();
        }


        public void Release()
        {
            OnRelease();
        }

        protected virtual void OnRelease(){}
        protected virtual void OnInit(){}
    }
}

