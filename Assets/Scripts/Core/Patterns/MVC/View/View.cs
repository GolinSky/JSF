using Core.Patterns.MVC.Controller;
using UnityEngine;

namespace Core.Patterns.MVC.View
{
    public abstract class View : MonoBehaviour
    {
        protected IController Controller
        {
            get
            {
                if (controller == null)
                {
                    controller = CreateController();
                }

                return controller;
            }
        }

        private IController controller;

        protected virtual void Start()
        {
            Controller.AddListeners();
        }

        protected virtual void OnDestroy()
        {
            if (Controller != null)
            {
                Controller.RemoveListeners();
            }
        }

        protected abstract IController CreateController();
        

      
    }

    public abstract class View<T> : View
    {
        public abstract void SetContext(T context);
    }
}