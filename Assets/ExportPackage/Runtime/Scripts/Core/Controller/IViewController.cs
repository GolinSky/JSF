namespace CodeFramework.Runtime
{
    public interface IViewController
    {
        TViewService GetService<TViewService>() where TViewService : IViewService;
        TComponent GetComponentObserver<TComponent>() where TComponent : IComponentObserver;

    }
}