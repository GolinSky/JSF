using CodeFramework.Runtime.Controllers.View;
using TMPro;
using UnityEngine;

namespace CodeFramework.Test
{
    public class SimpleView : View<ISimpleViewController>
    {
        [SerializeField] private TextMeshProUGUI text;

        public override ViewType ViewType => ViewType.Ui;
        
        protected override void OnInit()
        {
            UpdateText(ViewController.SimpleText);
            ViewController.OnUpdate += UpdateText;
        }
        
        protected override void OnBeforeDestroy()
        {
            ViewController.OnUpdate -= UpdateText;
        }

        private void UpdateText(string value)
        {
            text.text = value;

        }
    }
}


