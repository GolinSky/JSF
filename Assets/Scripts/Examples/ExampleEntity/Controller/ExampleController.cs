using Examples.ExampleEntity.Service;
using Examples.ExampleEntity.View;
using Runtime.Scripts.BaseServices.SceneService.Service;
using Runtime.Scripts.Patterns.MVC.Controller;
using Runtime.Scripts.Patterns.MVC.Factory;
using UnityEngine;
using Zenject;

namespace Examples.ExampleEntity.Controller
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
            View.SetContext(ExampleMessage);
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
