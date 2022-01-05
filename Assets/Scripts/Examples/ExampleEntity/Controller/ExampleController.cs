using UnityEngine.LevelEntity.Service;
using UnityEngine.MyPackage.Runtime.Scripts.BaseServices.SceneService.Service;
using UnityEngine.MyPackage.Runtime.Scripts.Patterns.MVC.Controller;
using UnityEngine.MyPackage.Runtime.Scripts.Patterns.MVC.ServiceLayer;
using UnityEngine.MyPackage.Runtime.Scripts.Patterns.MVC.View;
using Zenject;

namespace UnityEngine.Examples.ExampleEntity.Controller
{
    public class ExampleController : EventController<IView<string>, string> ,ITickable
    {
        private const string ExampleMessage = "Hello World";
        private readonly ILevelService levelService;
        private readonly IDtoLayer<SceneType> dtoLayer;
        private string context;

        [Inject]
        public ExampleController(IView<string> view, ILevelService levelService, IDtoLayer<SceneType> dtoLayer) : base(view)
        {
            this.levelService = levelService;
            this.dtoLayer = dtoLayer;
            View.SetContext(ExampleMessage);
        }
   
        public void Tick()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Debug.Log("Press key"); 
                dtoLayer.UpdateDto(SceneType.Example);
            }
        }

        protected override void HandleServiceLayer(string context)
        {
            Debug.Log($"{ExampleMessage}: {context}");
            levelService.LoadScene(SceneType.Example);
        }
    }
}
