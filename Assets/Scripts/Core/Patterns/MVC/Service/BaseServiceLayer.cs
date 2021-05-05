using Core.BaseServices.SceneService.Service;
using EventHandlerUtils;

namespace Core.Patterns.MVC.Service
{
    public abstract class BaseServiceLayer
    {
        public Handler DtoHandler { get; protected set; } = new Handler();

        public abstract bool IsInited { get; }
        
        public abstract SceneType ResetScene { get; }

        public abstract void Reset();

    }
}