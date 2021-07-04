using FrameworkCore.Patterns.MVC.Controller;
using UnityEngine;
using Zenject;

namespace FrameworkCore.Patterns.MVC.View
{
    public abstract class View : MonoBehaviour
    {
        protected IController Controller => controller;
       

        [Inject]
        protected IController controller;

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

    }

    public abstract class View<T> : View
    {
        public abstract void SetContext(T context);
    }
}