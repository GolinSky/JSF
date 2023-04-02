using System;
using CodeFramework.Runtime.Controller;

namespace CodeFramework.Runtime.View
{
    public abstract class View<TIViewController> : ViewBinding<TIViewController>
        where TIViewController : IViewController
    {
        private void Awake()
        {
            OnInit();
        }

        private void Update()
        {
            OnUpdate();
        }

        private void OnDestroy()
        {
            OnRelease();
        }

        protected abstract void OnInit();
        protected abstract void OnUpdate();
        protected abstract void OnRelease();
    }
}

