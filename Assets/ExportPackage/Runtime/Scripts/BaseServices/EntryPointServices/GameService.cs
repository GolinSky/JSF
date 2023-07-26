using CodeFramework.Runtime.Controllers.Observer;
using CodeFramework.Runtime.Controllers.View;
using GofPatterns.Patterns.Behavioral.Observer.Custom;

namespace CodeFramework.Runtime.Controllers.BaseServices
{
    public interface IEntryPoint
    {
        void StartGame();
    }

    public interface IGameService
    {
        IRepository<string> Repository { get; }
        IFactory<ViewBinding, Controller> ViewFactory { get; }
        ICustomSubject<float> TickService { get; }
    }

    public abstract class GameService : IEntryPoint, IGameService
    {
        protected ICustomSubject<float> TickService { get; }
        ICustomSubject<float> IGameService.TickService => TickService;
        protected abstract IRepository<string> Repository { get;  }
        IRepository<string> IGameService.Repository => Repository;
        protected abstract IFactory<ViewBinding, Controller> ViewFactory { get;  }
        IFactory<ViewBinding, Controller> IGameService.ViewFactory => ViewFactory;
        protected abstract BehaviourMap SceneMap { get;  }


        protected GameService()
        {
            var tickableFactory = new TickableCustomFactory();
            TickService = tickableFactory.Construct();
        }

        public void StartGame()
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