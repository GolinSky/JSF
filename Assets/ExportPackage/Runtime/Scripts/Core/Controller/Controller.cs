using System.Collections.Generic;

namespace CodeFramework.Runtime
{
    public interface IController : IViewController, IEntity
    {
        TComponent GetComponent<TComponent>() where TComponent : Component<IController>;
    }
    public abstract class Controller: IController
    {
        protected IHub<IService> ServiceHub { get; private set; }
        public virtual string Id => GetType().Name;

        private List<Component<IController>> components;

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

