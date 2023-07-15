using CodeFramework.Runtime.Controllers.View.Component;
using UnityEngine;

namespace CodeFramework.Runtime.Controllers.View
{
    public interface IView
    {
        ViewType ViewType { get; }
    }
    public abstract class View<TIViewController> : ViewBinding<TIViewController>, IView
        where TIViewController : IViewController
    {
        [SerializeField] private ViewComponent[] viewComponents;
        
        public abstract ViewType ViewType { get; }


        protected override void OnInit()
        {
            foreach (var viewComponent in viewComponents)
            {
                viewComponent.Init(ViewController);
            }

            base.OnInit();
        }

        protected override void OnBeforeDestroy()
        {
            base.OnBeforeDestroy();
            foreach (var viewComponent in viewComponents)
            {
                viewComponent.Release();
            }
        }

        public sealed override TViewComponent GetViewComponent<TViewComponent>()
        {
            foreach (var viewComponent in viewComponents)
            {
                if (viewComponent is TViewComponent component)
                {
                    return component;
                }
            }

            return default;
        }

        public sealed override bool TryGetViewComponent<TViewComponent>(out TViewComponent viewComponent)
        {
            viewComponent = default;

            foreach (var component in viewComponents)
            {
                if (component is TViewComponent targetComponent)
                {
                    viewComponent = targetComponent;
                    return true;
                }
            }

            return false;
        }
    }
}

