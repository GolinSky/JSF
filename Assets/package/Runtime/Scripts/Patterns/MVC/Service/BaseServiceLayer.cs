using EventHandlerUtils;
using Runtime.Scripts.BaseServices.ModelService.Service;
using Runtime.Scripts.BaseServices.SceneService.Service;

namespace Runtime.Scripts.Patterns.MVC.Service
{
    public abstract class BaseServiceLayer
    {
        protected readonly  IModelService modelService;

        protected BaseServiceLayer(IModelService modelService)
        {
            this.modelService = modelService;
        }
        public Handler DtoHandler { get; protected set; } = new Handler();

        public abstract bool IsInited { get; }
        
        public abstract SceneType ResetScene { get; }

        public abstract void Reset();

    }
}