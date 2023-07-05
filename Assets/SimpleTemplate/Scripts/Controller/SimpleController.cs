using System;
using System.Collections.Generic;
using System.Globalization;
using CodeFramework.Runtime;
using CodeFramework.Runtime.BaseServices;


namespace CodeFramework.Test
{
    public interface ISimpleViewController : IViewController
    {
        string SimpleText { get; }
        event Action<string> OnUpdate;
    }


    public interface ISimpleController : IController, ISimpleViewController {}


    public class SimpleController : Controller, ISimpleController,  IDisposable, ITick
    {
        public event Action<string> OnUpdate;

        public string SimpleText { get; private set; }

        public SimpleController(IGameService gameService) : base(gameService)
        {
            SimpleText = DateTime.UtcNow.ToString(CultureInfo.InvariantCulture);
        }

        protected override List<Component<IController>> BuildsComponents()
        {
            return new List<Component<IController>>
            {
                {new TickComponent(this)}
            };
        }

        public void Dispose()
        {
        }

        public void Update(float deltaTime)
        {
            SimpleText = DateTime.UtcNow.ToString(CultureInfo.InvariantCulture);
            OnUpdate?.Invoke(SimpleText);
        }
    }
}