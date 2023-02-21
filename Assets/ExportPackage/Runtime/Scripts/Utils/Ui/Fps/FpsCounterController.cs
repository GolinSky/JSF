using System.Globalization;
using UnityEngine.MyPackage.Runtime.Scripts.Patterns.MVC.Controller;
using UnityEngine.MyPackage.Runtime.Scripts.Patterns.MVC.View;
using Zenject;

namespace UnityEngine.MyPackage.Runtime.Scripts.Utils.Ui.Fps
{
    public class FpsCounterController : BaseController<IView<string>>, ITickable
    {
        private const float TimeCoefficient = 1.0f;
        private const float DeltaTimeCoefficient = 0.1f;
        private float deltaTime = 0.0f;

        public FpsCounterController(IView<string> view) : base(view)
        {
        }
        
        public void Tick()
        {
            deltaTime += (Time.unscaledDeltaTime - deltaTime) * DeltaTimeCoefficient;
            View.SetContext(((int) (TimeCoefficient / deltaTime)).ToString(CultureInfo.InvariantCulture));
        }
    }
}
