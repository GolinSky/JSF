using UnityEngine.MyPackage.Runtime.Scripts.Patterns.MVC.ServiceLayer;
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