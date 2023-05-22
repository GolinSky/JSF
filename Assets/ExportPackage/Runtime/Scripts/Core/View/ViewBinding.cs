namespace CodeFramework.Runtime.View
{

    public abstract class ViewBinding : CustomMonoBehaviour
    {
        public abstract void Init(IViewController viewController);
    }
    
    public abstract class ViewBinding<TIViewController> : ViewBinding
        where TIViewController : IViewController
    {
        protected TIViewController ViewController { get; private set; }

        public virtual void Destroy()
        {
            OnBeforeDestroy();
            Destroy(gameObject);
        }

        public sealed override void Init(IViewController viewController)
        {
            ViewController = (TIViewController)viewController;
        }
        
        protected virtual void OnBeforeDestroy()
        {
            
        }
        
    }
}