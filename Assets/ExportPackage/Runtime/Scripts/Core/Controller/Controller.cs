using System.Collections.Generic;
using CodeFramework.Runtime.BaseServices;
using CodeFramework.Runtime.Observer;

namespace CodeFramework.Runtime
{
    public interface IController : IViewController, IEntity
    {
        TComponent GetComponent<TComponent>() where TComponent : Component<IController>;
    }
    public abstract class Controller: IController
    {
        private List<Component<IController>> components;

        protected IGameService GameService { get; }
        protected IHub<IService> ServiceHub { get; private set; }

        public ObserverSubject<float> TickService => GameService.TickService;

        public virtual string Id => GetType().Name;


        public Controller(IGameService gameService)
        {
            GameService = gameService;
        }
        public void Init(IHub<IService> serviceHub)
        {
            ServiceHub = serviceHub;
            components = BuildsComponents();
            foreach (var component in components)
            {
                component.Init(this);
            }
            OnInit();
        }

        protected virtual List<Component<IController>> BuildsComponents()
        {
            return new List<Component<IController>>();
        }

        public void Release()
        {
            OnRelease();
            foreach (var component in components)
            {
                component.Release();
            }
        }

        public TComponent GetComponent<TComponent>() where TComponent : Component<IController>
        {
            return GetComponentInternal<TComponent>();
        }

        public TComponent GetComponentObserver<TComponent>() where TComponent : IComponentObserver
        {
            return GetComponentInternal<TComponent>();
        }

        private T GetComponentInternal<T>() // make extension 
        {
            foreach (var component in components)
            {
                if (component is T targetComponent)
                {
                    return targetComponent;
                }
            }

            return default;
        }


        public TViewService GetService<TViewService>() where TViewService : IViewService
        {
            return ServiceHub.Get<TViewService>();
        }
        
        protected virtual void OnRelease(){}
        protected virtual void OnInit(){}
    }
}

