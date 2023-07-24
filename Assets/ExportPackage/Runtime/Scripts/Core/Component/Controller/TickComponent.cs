using CodeFramework.Runtime.Controllers.Observer;
using GofPatterns.Patterns.Behavioral.Observer.Custom;

namespace CodeFramework.Runtime.Controllers
{
    public interface ITick
    {
        void Update(float deltaTime);
    }
    public class TickComponent:ControllerComponent, ICustomObserver<float>
    {
        private ICustomSubject<float> tickService;
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

     
        public void Notify(float state)
        {
            Tick.Update(state);
        }
    }
}