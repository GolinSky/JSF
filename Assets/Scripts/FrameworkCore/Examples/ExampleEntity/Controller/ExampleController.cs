using System;
using FrameworkCore.BaseServices.SceneService.Service;
using FrameworkCore.Examples.ExampleEntity.Service;
using FrameworkCore.Examples.ExampleEntity.View;
using FrameworkCore.Patterns.MVC.Controller;
using FrameworkCore.Patterns.MVC.Factory;
using UnityEngine;

namespace FrameworkCore.Examples.ExampleEntity.Controller
{
    public class ExampleController : Controller<ExampleView>
    {
        private const string ExampleMessage = "Hello World";
        private readonly ILevelService levelService;
        public ExampleController(ExampleView view, ILevelService levelService) : base(view)
        {
            view.SetContext(ExampleMessage + DateTime.Now.Second);
            this.levelService = levelService;
        }
        
        public override void Execute()
        {
            base.Execute();
            if (Input.GetKeyDown(KeyCode.Space))
            {
                // Service.UpdateDto(true);
                // var context = Service.GetContext();
                // Debug.Log(context);
                levelService.LoadScene(SceneType.Example);
            }
        }

        private  ExampleServiceLayer Service => ServiceFactory.GetService<ExampleServiceLayer>();
    }
}
