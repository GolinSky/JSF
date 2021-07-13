using UnityEngine.LevelEntity.Model;
using UnityEngine.MyPackage.Runtime.Scripts.BaseServices.ModelService.Service;
using UnityEngine.MyPackage.Runtime.Scripts.BaseServices.SceneService.Model;
using UnityEngine.MyPackage.Runtime.Scripts.BaseServices.SceneService.Service;
using UnityEngine.MyPackage.Runtime.Scripts.Patterns.MVC.Service;

namespace UnityEngine.Examples.ExampleEntity.Service
{
    public class ExampleServiceLayer : ServiceLayer<LevelModel, bool, string>
    {
        public override string GetContext()
        {
            return Model.GetByType(SceneType.Example);
        }

        public ExampleServiceLayer(IModelService modelService) : base(modelService)
        {
        }
    }
}
