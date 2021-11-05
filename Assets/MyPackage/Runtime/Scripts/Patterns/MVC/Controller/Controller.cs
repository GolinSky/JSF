using UnityEngine.MyPackage.Runtime.Scripts.Patterns.MVC.Factory;
using UnityEngine.MyPackage.Runtime.Scripts.Patterns.MVC.ServiceLayer;
using Zenject;

namespace UnityEngine.MyPackage.Runtime.Scripts.Patterns.MVC.Controller
{
    public abstract class UpdateController : ITickable
    {
        public abstract void Tick();
    }

    public abstract class Controller<T> : IController where T : View.View
    {
        protected T View { get; }

        [Inject]
        public Controller(T view)
        {
            View = view;
        }


        public virtual void AddListeners()
        {
        }

        public virtual void RemoveListeners()
        {
        }

        public virtual void Execute()
        {
        }
    }

    public abstract class Controller<T, Context, ContextLayer> : Controller<T>
        where T : View.View where ContextLayer : IContextLayer<Context>
    {
        protected readonly ContextLayer contextLayer;

        [Inject]
        protected Controller(T view, ContextLayer contextLayer) : base(view)
        {
            this.contextLayer = contextLayer;
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