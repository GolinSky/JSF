using CodeFramework.Runtime.Observer;
using CodeFramework.Runtime.View;

namespace CodeFramework.Runtime.BaseServices
{

    public interface IGameService
    {
        void Start();
    }
    public abstract class GameService:IGameService
    {
        protected ObserverSubject<float> TickService { get; }
        protected abstract IRepository<string> Repository { get; }
        protected abstract IFactory<ViewBinding, Controller> ViewFactory { get; }
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