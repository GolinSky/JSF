﻿using UnityEngine.MyPackage.Runtime.Scripts.Patterns.MVC.View;
using UnityEngine.UI;

namespace UnityEngine.Examples.ExampleEntity.View
{
    public class ExampleView : View<string>
    {
        [SerializeField] private Text text;
    
        public override void SetContext(string context)
        {
            text.text = context;
        }

        private void Update()
        {
            Controller.Execute();
        }
    }
}
