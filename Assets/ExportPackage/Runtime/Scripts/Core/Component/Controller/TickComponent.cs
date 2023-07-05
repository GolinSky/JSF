using CodeFramework.Runtime.Observer;

namespace CodeFramework.Runtime
{
    public interface ITick
    {
        void Update(float deltaTime);
    }
    public class TickComponent:ControllerComponent, ICustomObserver<float>
    {
        private ObserverSubject<float> tickService;
        protected ITick Tick { get; }

        public TickComponent(ITick tick)
        {
            Tick = tick;
        }
        
        protected override void OnInit(IController controller)
        {
            tickService = Controller.TickService;
            tickService.AddObserver(this);
        }

        protected override void OnRelease()
        {
            if (tickService != null)
            {
                tickService.RemoveObserver(this);
            }
        }

        public void UpdateState(float state)
        {
            Tick.Update(state);
        }
    }
}