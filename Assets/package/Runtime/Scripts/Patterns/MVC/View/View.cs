using UnityEngine.Package.Runtime.Scripts.Patterns.MVC.Controller;
using Zenject;

namespace UnityEngine.Package.Runtime.Scripts.Patterns.MVC.View
{
    public abstract class View : MonoBehaviour
    {
        [Inject]
        protected readonly IController Controller;
        
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