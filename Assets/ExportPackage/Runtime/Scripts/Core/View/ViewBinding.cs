using CodeFramework.Runtime.View.Component;
using UnityEngine;

namespace CodeFramework.Runtime.View
{
    public abstract class ViewBinding : CustomMonoBehaviour
    {
        public abstract IViewController Controller { get; }
        protected Transform Transform { get; private set; }
        private Vector3 Position => Transform.position;

        private void Start()
        {
            Transform = transform;//cash
        }

        public abstract void Init(IViewController viewController);
        public abstract void Release();
        public abstract TViewComponent GetViewComponent<TViewComponent>() where TViewComponent : IViewComponent;
        public abstract bool TryGetViewComponent<TViewComponent>(out TViewComponent viewComponent) where TViewComponent : IViewComponent;

    }
    
    public abstract class ViewBinding<TViewController> : ViewBinding
        where TViewController : IViewController
    {
        public override IViewController Controller => ViewController;
        protected TViewController ViewController { get; private set; }

        public sealed override void Release()
        {
            OnBeforeDestroy();
            Destroy(gameObject);
        }

        public sealed override void Init(IViewController viewController)
        {
            ViewController = (TViewController)viewController;
            OnInit();
        }
        
        protected virtual void OnBeforeDestroy() {}
        protected virtual void OnInit() {}
        
    }
}