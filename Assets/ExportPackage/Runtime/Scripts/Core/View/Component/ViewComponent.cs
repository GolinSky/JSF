﻿namespace CodeFramework.Runtime.Controllers.View.Component
{
    public abstract class ViewComponent<TViewController>: CustomMonoBehaviour, IViewComponent<TViewController> where TViewController : IViewController
    {
        protected TViewController ViewController { get; private set; }

        public void Init(TViewController viewController)
        {
            ViewController = viewController;
            OnInit();
        }

        public void Release()
        {
            OnRelease();
        }

        protected virtual void OnInit(){}
        protected virtual void OnRelease(){}
    }

    public abstract class ViewComponent : ViewComponent<IViewController>
    {
        
    }
}