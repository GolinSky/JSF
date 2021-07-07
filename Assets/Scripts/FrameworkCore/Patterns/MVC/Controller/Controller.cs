using FrameworkCore.MonoBehaviourEntity.Service;
using FrameworkCore.Patterns.MVC.Factory;
using FrameworkCore.Patterns.MVC.Service;

namespace FrameworkCore.Patterns.MVC.Controller
{

    public abstract class UpdateController: GraspController<IUpdater>
    {
        protected UpdateController(IUpdater service) : base(service)
        {
        }
        
        protected override void AddListeners()
        {
            base.AddListeners();
            service.OnUpdate += Update;
        }

        protected override void RemoveListeners()
        {
            base.RemoveListeners();
            service.OnUpdate -= Update;
        }

        protected abstract void Update();

    }
    public abstract class GraspController<T> where T:class
    {
        protected readonly T service;
        protected GraspController(T service)
        {
            this.service = service;
            AddListeners();
        }
        ~GraspController()
        {
            RemoveListeners();
        }

        protected virtual void AddListeners(){}
        protected virtual void RemoveListeners(){}
        public virtual void Execute(){}
    }
    
    public abstract class Controller<T>:IController where T:View.View
    {
        protected T View { get; }

        public Controller(T view)
        {
            this.View = view;
        }

        public virtual void AddListeners(){}
        public virtual void RemoveListeners(){}

        public virtual void Execute(){}
    }

    public abstract class Controller<T, Layer> :Controller<T> where T : View.View where Layer:BaseServiceLayer
    {
        protected readonly Layer serviceLayer;
        protected Controller(T view) : base(view)
        {
            serviceLayer = ServiceFactory.GetService<Layer>();
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