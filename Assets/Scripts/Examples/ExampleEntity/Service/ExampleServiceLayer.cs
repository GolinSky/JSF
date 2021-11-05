using UnityEngine.Examples.LevelEntity.Model;
using UnityEngine.MyPackage.Runtime.Scripts.BaseServices.ModelService.Service;
using UnityEngine.MyPackage.Runtime.Scripts.BaseServices.SceneService.Service;
using UnityEngine.MyPackage.Runtime.Scripts.Patterns.MVC.ServiceLayer;

namespace UnityEngine.Examples.ExampleEntity.Service
{
    public class ExampleServiceLayer : ServiceLayer<SceneType,string,LevelModel>
    {
        protected override string GetContext()
        {
            return Model.GetByType(dto);
        }

        public ExampleServiceLayer(IModelService modelService) : base(modelService)
        {
        }
    }
}
