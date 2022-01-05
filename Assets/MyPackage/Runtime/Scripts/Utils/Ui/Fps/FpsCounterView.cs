using UnityEngine.MyPackage.Runtime.Scripts.Patterns.MVC.View;
using UnityEngine.UI;

#pragma warning disable 0649

namespace UnityEngine.MyPackage.Runtime.Scripts.Utils.Ui.Fps
{
    public class FpsCounterView : BaseView<string>
    {
        [SerializeField] private Text fpsLabel;
        

        public override void SetContext(string context)
        {
            fpsLabel.text = context;
        }
    }
}
