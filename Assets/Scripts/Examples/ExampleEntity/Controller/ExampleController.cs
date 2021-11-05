using UnityEngine.Examples.ExampleEntity.View;
using UnityEngine.LevelEntity.Service;
using UnityEngine.MyPackage.Runtime.Scripts.BaseServices.SceneService.Service;
using UnityEngine.MyPackage.Runtime.Scripts.Patterns.MVC.Controller;
using UnityEngine.MyPackage.Runtime.Scripts.Patterns.MVC.ServiceLayer;
using Zenject;

namespace UnityEngine.Examples.ExampleEntity.Controller
{
    public class ExampleController : Controller<ExampleView, string, IContextLayer<string>>
    {
        private const string ExampleMessage = "Hello World ";
        private readonly ILevelService levelService;
        private readonly IDtoLayer<SceneType> dtoLayer;
        private string context;

        [Inject]
        public ExampleController(ExampleView view, ILevelService levelService,  IContextLayer<string> contextLayer, IDtoLayer<SceneType> dtoLayer) : base(view, contextLayer)
        {
            this.levelService = levelService;
            this.dtoLayer = dtoLayer;
            View.SetContext(ExampleMessage);
        }

        protected override void HandleServiceLayer(string context)
        {
            Debug.Log(ExampleMessage+context);
            levelService.LoadScene(SceneType.Example);
        }

        public override void Execute()
        {
            base.Execute();
            if (Input.GetKeyDown(KeyCode.Space))
            {
                dtoLayer.UpdateDto(SceneType.Example);
            }
        }

    }
}
