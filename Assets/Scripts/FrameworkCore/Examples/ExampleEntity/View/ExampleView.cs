using UnityEngine;
using UnityEngine.UI;

namespace FrameworkCore.Examples.ExampleEntity.View
{
    public class ExampleView : Patterns.MVC.View.View<string>
    {
        [SerializeField] private Text text;
    
        public override void SetContext(string context)
        {
            text.text = context;
        }
    }
}
