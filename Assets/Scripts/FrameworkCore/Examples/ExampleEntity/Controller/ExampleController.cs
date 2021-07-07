using System;
using FrameworkCore.BaseServices.SceneService.Service;
using FrameworkCore.Examples.ExampleEntity.View;
using FrameworkCore.Patterns.MVC.Controller;
using UnityEngine;
using Zenject;

namespace FrameworkCore.Examples.ExampleEntity.Controller
{
    public class ExampleController : Controller<ExampleView>
    {
        private const string ExampleMessage = "Hello World";
        [Inject]
        private readonly ILevelService levelService;
     
        public ExampleController(ExampleView view) : base(view)
        {
            view.SetContext(ExampleMessage+DateTime.Now.Second);
        }

        public override void AddListeners()
        {
        }

        public override void RemoveListeners()
        {
        }

        public override void Execute()
        {
            base.Execute();
            if (Input.GetKeyDown(KeyCode.Space))
            {
                levelService.LoadScene(SceneType.Example);
            }
        }
    }
}
