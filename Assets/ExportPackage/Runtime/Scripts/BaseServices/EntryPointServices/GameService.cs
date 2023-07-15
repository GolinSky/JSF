using CodeFramework.Runtime.Controllers.Observer;
using CodeFramework.Runtime.Controllers.View;

namespace CodeFramework.Runtime.Controllers.BaseServices
{
    public interface IEntryPoint
    {
        void Start();
    }

    public interface IGameService
    {
        IRepository<string> Repository { get; }
        IFactory<ViewBinding, Controller> ViewFactory { get; }
        ObserverSubject<float> TickService { get; }
    }

    public abstract class GameService : IEntryPoint, IGameService
    {
        protected ObserverSubject<float> TickService { get; }
        ObserverSubject<float> IGameService.TickService => TickService;
        protected IRepository<string> Repository { get; set; }
        IRepository<string> IGameService.Repository => Repository;
        protected IFactory<ViewBinding, Controller> ViewFactory { get; set; }
        IFactory<ViewBinding, Controller> IGameService.ViewFactory => ViewFactory;
        protected BehaviourMap SceneMap { get; set; }


        protected GameService()
        {
            var tickableFactory = new TickableCustomFactory();
            TickService = tickableFactory.Construct();
        }

        public void Start()
        {
            //todo: initialization
            OnBeforeStart();
            SceneMap.Load();
            OnStart();
        }

        protected abstract void OnStart();
        protected abstract void OnBeforeStart();
    }
}