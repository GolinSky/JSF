using CodeFramework.Runtime.Controller;

namespace CodeFramework.Runtime.View
{
    public abstract class ViewBinding<TIViewController> : CustomMonoBehaviour
        where TIViewController : IViewController
    {
        protected TIViewController ViewController { get; private set; }

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