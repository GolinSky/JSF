namespace CodeFramework.Runtime.View.Component
{
    public abstract class ViewComponent<TViewController>: CustomMonoBehaviour, IViewComponent<TViewController> where TViewController : IViewController
    {
        protected TViewController ViewController { get; private set; }

        public void Init(TViewController viewController)
        {
            ViewController = viewController;
        }

        public void Release()
        {
        }
    }
}