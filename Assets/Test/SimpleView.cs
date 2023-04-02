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
            text.text = ViewController.SimpleText;
        }

        protected override void OnUpdate()
        {
        }

        protected override void OnRelease()
        {
        }
    }
}