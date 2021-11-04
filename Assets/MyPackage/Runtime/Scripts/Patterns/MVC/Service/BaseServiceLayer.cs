using EventHandlerUtils;
using UnityEngine.MyPackage.Runtime.Scripts.BaseServices.ModelService.Service;
using UnityEngine.MyPackage.Runtime.Scripts.BaseServices.SceneService.Service;

namespace UnityEngine.MyPackage.Runtime.Scripts.Patterns.MVC.Service
{
    public abstract class BaseServiceLayer
    {
        protected readonly  IModelService ModelService;

        protected BaseServiceLayer(IModelService modelService)
        {
            this.ModelService = modelService;
        }
        public Handler DtoHandler { get; protected set; } = new Handler();

        public abstract bool IsInited { get; }
        
        // public abstract SceneType ResetScene { get; }

        public abstract void Reset();

    }
}