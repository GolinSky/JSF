using FrameworkCore.BaseServices.SceneService.Service;
using FrameworkCore.Examples.ExampleEntity.Service;
using FrameworkCore.Examples.ExampleEntity.View;
using FrameworkCore.Patterns.MVC.Controller;
using FrameworkCore.Patterns.MVC.Factory;
using UnityEngine;
using Zenject;

namespace FrameworkCore.Examples.ExampleEntity.Controller
{
    public class ExampleController : Controller<ExampleView, ExampleServiceLayer>
    {
        private const string ExampleMessage = "Hello World ";
        private readonly ILevelService levelService;
        private string context;

        [Inject]
        public ExampleController(ExampleView view, ILevelService levelService, IServiceFactory serviceFactory) : base(view, serviceFactory)
        {
            this.levelService = levelService;
        }

        public override void Execute()
        {
            base.Execute();
            if (Input.GetKeyDown(KeyCode.Space))
            {
                serviceLayer.UpdateDto(true);

                Debug.Log(ExampleMessage+context);
                levelService.LoadScene(SceneType.Example);
                
            }
        }

        protected override void HandleServiceLayer()
        {
            context = serviceLayer.GetContext();
        }
    }
}
