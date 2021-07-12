using Runtime.Scripts.BaseServices.ModelService.Service;
using Runtime.Scripts.BaseServices.SceneService.Model;
using Runtime.Scripts.BaseServices.SceneService.Service;
using Runtime.Scripts.Patterns.MVC.Service;

namespace Examples.ExampleEntity.Service
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
