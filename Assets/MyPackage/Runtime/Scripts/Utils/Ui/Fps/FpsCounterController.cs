using System.Globalization;
using UnityEngine.MyPackage.Runtime.Scripts.Patterns.MVC.Controller;
using UnityEngine.MyPackage.Runtime.Scripts.Patterns.MVC.Factory;

namespace UnityEngine.MyPackage.Runtime.Scripts.Utils.Ui.Fps
{
    public class FpsCounterController : Controller<FpsCounterView>
    {
        private const float TimeCoefficient = 1.0f;
        private const float DeltaTimeCoefficient = 0.1f;
        private float deltaTime = 0.0f;

        public FpsCounterController(FpsCounterView view) : base(view)
        {
        }

        public override void AddListeners()
        {
        }

        public override void RemoveListeners()
        {
        }

        public override void Execute()
        {
            deltaTime += (Time.unscaledDeltaTime - deltaTime) * DeltaTimeCoefficient;
            View.SetContext(((int) (TimeCoefficient / deltaTime)).ToString(CultureInfo.InvariantCulture));
        }
    }
}
