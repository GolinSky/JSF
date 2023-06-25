using CodeFramework.Runtime.Observer;

namespace CodeFramework.Runtime
{
    public interface IViewController
    {
        ObserverSubject<float> TickService { get; }
        TViewService GetService<TViewService>() where TViewService : IViewService;
        TComponent GetComponentObserver<TComponent>() where TComponent : IComponentObserver;

    }
}