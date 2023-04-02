using UnityEngine.MyPackage.Runtime.Scripts.Patterns.MVC.ServiceLayer;
using UnityEngine.MyPackage.Runtime.Scripts.Patterns.MVC.View;
using Zenject;

namespace UnityEngine.MyPackage.Runtime.Scripts.Patterns.MVC.Controller
{
    public abstract class UpdateController : ITickable
    {
        public abstract void Tick();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T">View</typeparam>
    public abstract class BaseController<T> where T:IView
    {
        protected T View { get; }
        protected BaseController(T view)
        {
            View = view;
        }
      
    }
    
    
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T">View</typeparam>
    public abstract class EventController<T>:BaseController<T>,IInitializable, ILateDisposable where T:IView  
    {
 
        protected EventController(T view) : base(view)
        {
        }

        public void Initialize()
        {
            AddListeners();
        }

        public void LateDispose()
        {
            RemoveListeners();
        }

        protected abstract void AddListeners();
        protected abstract void RemoveListeners();

    }
    
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T">View</typeparam>
    /// <typeparam name="C">Context from service layer</typeparam>
    public abstract class EventController<T,C>:EventController<T> where T:IView  
    {
        [Inject]
        private readonly IContextLayer<C> contextLayer;
        protected EventController(T view) : base(view)
        {
        }

        protected sealed override void AddListeners()
        {
            contextLayer.AddListener(HandleServiceLayer);
            AddListenersInternal();
        }

        protected sealed override void RemoveListeners()
        {
            contextLayer.RemoveListener(HandleServiceLayer);
            RemoveListenersInternal();
        }

        protected virtual void AddListenersInternal(){}
        protected virtual void RemoveListenersInternal(){}
        
        protected abstract void HandleServiceLayer(C context);

    }

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T">View</typeparam>
    public abstract class Controller<T> : IController where T : View.View
    {
        protected T View { get; }

        [Inject]
        public Controller(T view)
        {
            View = view;
        }
        
        public virtual void AddListeners() {}

        public virtual void RemoveListeners() {}

        public virtual void Execute() {}
    }
/// <summary>
/// 
/// </summary>
/// <typeparam name="T">View</typeparam>
/// <typeparam name="Context"> Context that will be taken from service layer</typeparam>
    public abstract class Controller<T, Context> : Controller<T> where T : View.View 
    {
        [Inject]
        private readonly IContextLayer<Context> contextLayer;

        [Inject]
        protected Controller(T view) : base(view)
        {
        }

        public sealed override void AddListeners()
        {
            contextLayer.AddListener(HandleServiceLayer);
            AddInternalListeners();
        }

        public sealed override void RemoveListeners()
        {
            contextLayer.RemoveListener(HandleServiceLayer);
            RemoveInternalListeners();
        }

        protected abstract void HandleServiceLayer(Context context);
        protected virtual void AddInternalListeners() {}
        protected virtual void RemoveInternalListeners() {}

    }
}