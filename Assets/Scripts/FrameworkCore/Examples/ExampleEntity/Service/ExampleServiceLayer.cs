using FrameworkCore.BaseServices.ModelService.Service;
using FrameworkCore.BaseServices.SceneService.Model;
using FrameworkCore.BaseServices.SceneService.Service;
using FrameworkCore.Patterns.MVC.Service;

namespace FrameworkCore.Examples.ExampleEntity.Service
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
