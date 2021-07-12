using UnityEngine.Package.Runtime.Scripts.Patterns.MVC.View;
using UnityEngine.UI;

#pragma warning disable 0649

namespace UnityEngine.Package.Runtime.Scripts.Utils.Ui.Fps
{
    public class FpsCounterView : View<string>
    {
        [SerializeField] private Text fpsLabel;

        private void Update()
        {
           Controller.Execute();
        }

        public override void SetContext(string context)
        {
            fpsLabel.text = context;
        }
    }
}
