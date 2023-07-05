namespace CodeFramework.Runtime
{
    public abstract class ControllerComponent : Component<IController>
    {
        protected IController Controller { get; private set; }
        
        public sealed override void Init(IController controller)
        {
            Controller = controller;
            OnInit(controller);
        }

        public sealed override void Release()
        {
            OnRelease();
        }

        protected TService GetService<TService>() where TService : IService
        {
            return Controller.GetService<TService>();
        }

        protected abstract void OnInit(IController controller);
        protected abstract void OnRelease();
    }
}