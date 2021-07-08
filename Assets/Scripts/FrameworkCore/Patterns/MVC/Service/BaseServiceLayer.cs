using EventHandlerUtils;
using FrameworkCore.BaseServices.ModelService.Service;
using FrameworkCore.BaseServices.SceneService.Service;
using Zenject;

namespace FrameworkCore.Patterns.MVC.Service
{
    public abstract class BaseServiceLayer
    {
        [Inject]
        protected  IModelService modelService;
        public Handler DtoHandler { get; protected set; } = new Handler();

        public abstract bool IsInited { get; }
        
        public abstract SceneType ResetScene { get; }

        public abstract void Reset();

    }
}