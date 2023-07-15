using CodeFramework.Runtime.Controllers.Observer;

namespace CodeFramework.Runtime.Controllers
{
    public interface IViewController
    {
        ObserverSubject<float> TickService { get; }
        TViewService GetService<TViewService>() where TViewService : IViewService;
        TComponent GetComponentObserver<TComponent>() where TComponent : IComponentObserver;

    }
}