using System.Globalization;
using FrameworkCore.Patterns.MVC.Controller;
using FrameworkCore.Patterns.MVC.View;
using UnityEngine;
using UnityEngine.UI;

#pragma warning disable 0649

namespace FrameworkCore.Utils.Ui
{
    public class FpsCounterView : View
    {
        [SerializeField] private Text fpsLabel;


        private void Update()
        {
           Controller.Execute();
        }

        public void SetText(string value)
        {
            fpsLabel.text = value;
        }

    //    protected override IController CreateController() => new FpsCounterController(this);

    }

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
            View.SetText(((int) (TimeCoefficient / deltaTime)).ToString(CultureInfo.InvariantCulture));
        }
    }
}
