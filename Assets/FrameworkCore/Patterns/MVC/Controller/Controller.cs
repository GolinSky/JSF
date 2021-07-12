using FrameworkCore.Patterns.MVC.Factory;
using FrameworkCore.Patterns.MVC.Service;
using Zenject;

namespace FrameworkCore.Patterns.MVC.Controller
{

  
    public abstract class UpdateController:ITickable
    {
        public abstract void Tick();

    }
    
    public abstract class Controller<T>:IController where T:View.View
    {
        protected readonly IServiceFactory serviceFactory;
        protected T View { get; }

        [Inject]
        public Controller(T view, IServiceFactory serviceFactory)
        {
            View = view;
            this.serviceFactory = serviceFactory;
        }

        public virtual void AddListeners(){}
        public virtual void RemoveListeners(){}

        public virtual void Execute(){}
    }

    public abstract class Controller<T, Layer> :Controller<T> where T : View.View where Layer:BaseServiceLayer
    {
        protected readonly Layer serviceLayer;
        [Inject]
        protected Controller(T view, IServiceFactory serviceFactory) : base(view, serviceFactory)
        {
            serviceLayer = serviceFactory.GetService<Layer>();

        }

        public override void AddListeners()
        {
            serviceLayer.DtoHandler.AddListener(HandleServiceLayer);
        }

        public override void RemoveListeners()
        {
            RemoveServiceLayerListener();
        }

        protected abstract void HandleServiceLayer();
        
        protected void RemoveServiceLayerListener() => serviceLayer.DtoHandler.RemoveListener(HandleServiceLayer);

    }
}