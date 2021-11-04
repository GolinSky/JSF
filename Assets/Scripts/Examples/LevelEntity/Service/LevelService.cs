using UnityEngine.Examples.LevelEntity.Model;
using UnityEngine.MyPackage.Runtime.Scripts.BaseServices.ModelService.Service;
using UnityEngine.MyPackage.Runtime.Scripts.BaseServices.SceneService.Service;
using UnityEngine.MyPackage.Runtime.Scripts.Utils.Scene;

namespace UnityEngine.LevelEntity.Service
{
    public class LevelService : BaseLevelService<SceneType>, ILevelService
    {
        private  LevelModel LevelModel;

        public LevelService(IModelService modelService) : base(modelService)
        {
            LevelModel = modelService.GetModel<LevelModel>();
            LoadScene(EntryScene);
        }

        protected override SceneType EntryScene => SceneType.Navigation;
        public override AsyncOperation LoadSceneAsync()
        {
            return SceneTools.LoadSceneAsync(LevelModel.GetByType(CurrentScene));
        }

        protected override void InternalLoadScene()
        {
            SceneTools.LoadScene(LevelModel.GetByType(SceneType.Loading));

        }
    }
    
    public interface ILevelService:IBaseLevelService<SceneType>
    {
     
    }
}
