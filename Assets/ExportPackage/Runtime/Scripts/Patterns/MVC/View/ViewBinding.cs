using CodeFramework.Runtime.Controller;
using Zenject;

namespace CodeFramework.Runtime.View
{
    public abstract class ViewBinding<TIViewController> : CustomMonoBehaviour
        where TIViewController : IViewController
    {
        [Inject] protected TIViewController ViewController { get; private set; }

        public virtual void Destroy()
        {
            OnBeforeDestroy();
            Destroy(gameObject);
        }

        protected virtual void OnBeforeDestroy()
        {
            
        }

}
}