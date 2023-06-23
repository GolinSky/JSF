namespace CodeFramework
{
    public interface IService:IEntity
    {
        
    }
    
    public abstract class Service:IService
    {
        protected IHub<IService> ServiceHub { get; private set; }

        public string Id => GetType().Name;

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