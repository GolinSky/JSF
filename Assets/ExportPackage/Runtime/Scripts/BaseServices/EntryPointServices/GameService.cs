using CodeFramework.Runtime.Observer;
using CodeFramework.Runtime.View;

namespace CodeFramework.Runtime.BaseServices
{
    public interface IEntryPoint
    {
        void Start();
    }

    public interface IGameService
    {
        IRepository<string> Repository { get; }
        IFactory<ViewBinding, Controller> ViewFactory { get; }
    }

    public abstract class GameService : IEntryPoint, IGameService
    {
        protected ObserverSubject<float> TickService { get; }
        protected IRepository<string> Repository { get; set; }
        IRepository<string> IGameService.Repository => Repository;
        protected IFactory<ViewBinding, Controller> ViewFactory { get; set; }
        IFactory<ViewBinding, Controller> IGameService.ViewFactory => ViewFactory;
        protected abstract BehaviourMap SceneMap { get; }


        protected GameService()
        {
            TickService = TickableCustomFactory.Construct();
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