namespace CodeFramework.Runtime.View.Component
{
    public interface IViewComponent
    {
        void Release();
    }
    public interface IViewComponent<TViewController>:IViewComponent 
        where TViewController: IViewController
    {
        void Init(TViewController viewController);
    }
}