using CodeFramework.Runtime.View;
using UnityEngine;
using UnityEngine.UI;

namespace CodeFramework.Test
{
    public class SimpleView : View<ISimpleViewController>
    {
        [SerializeField] private Text text;

        protected override void OnInit()
        {
            UpdateText(ViewController.SimpleText);
            ViewController.OnUpdate += UpdateText;
        }
        
        protected override void OnRelease()
        {
            ViewController.OnUpdate -= UpdateText;
        }

        private void UpdateText(string value)
        {
            text.text = value;

        }

        protected override void OnUpdate()
        {
        }

        
    }
}