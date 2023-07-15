using CodeFramework.Runtime.Controllers.BaseServices;

namespace CodeFramework
{
    public interface IViewService
    {
        
    }
    public interface IService:IEntity, IViewService
    {
        
    }
    
    public abstract class Service: IService
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
            OnInit();
        }

        public void Release()
        {
            ServiceHub.Remove(this);
            OnRelease();
        }

        protected virtual void OnInit(){}
        protected virtual void OnRelease(){}
        
    }
}