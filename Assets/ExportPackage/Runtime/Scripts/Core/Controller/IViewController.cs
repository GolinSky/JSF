using CodeFramework.Runtime.Controllers.Observer;
using GofPatterns.Patterns.Behavioral.Observer.Custom;

namespace CodeFramework.Runtime.Controllers
{
    public interface IViewController
    {
        ICustomSubject<float> TickService { get; }
        TViewService GetService<TViewService>() where TViewService : IViewService;
        TComponent GetComponentObserver<TComponent>() where TComponent : IComponentObserver;

    }
}