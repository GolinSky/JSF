using CodeFramework.Runtime.BaseServices;

namespace CodeFramework
{
    public interface IService:IEntity
    {
        
    }
    
    public abstract class Service:IService
    {
        protected IGameService GameService { get; }
        protected IHub<IService> ServiceHub { get; private set; }
        public string Id => GetType().Name;

        protected Service(IGameService gameService)
        {
            GameService = gameService;
        }

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