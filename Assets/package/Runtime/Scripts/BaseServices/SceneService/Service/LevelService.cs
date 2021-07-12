using EventHandlerUtils;
using UnityEngine.Package.Runtime.Scripts.BaseServices.ModelService.Service;
using UnityEngine.Package.Runtime.Scripts.BaseServices.SceneService.Model;
using UnityEngine.Package.Runtime.Scripts.Utils.Scene;

namespace UnityEngine.Package.Runtime.Scripts.BaseServices.SceneService.Service
{
    public class LevelService:ILevelService
    {
        public const SceneType EntryScene = SceneType.Example;
        private  LevelModel LevelModel;
        private  SceneType PreviousScene = SceneType.Loading;

        public  Handler<SceneType> SceneLoadedHandler { get; } = new Handler<SceneType>();
        public  Handler<SceneType> SceneUnloadedHandler { get; } = new Handler<SceneType>();
        public  SceneType CurrentScene { get; private set; }

        public LevelService(IModelService modelService)
        {
            LevelModel = modelService.GetModel<LevelModel>();

            if (Application.isEditor)
            {
                var currentSceneType = LevelModel.GetTypeByName(SceneTools.ActiveScene.path);
                if (currentSceneType != SceneType.Loading)
                {
                    LoadScene(currentSceneType);
                }
                else
                {
                    LoadScene(EntryScene);
                }
            }
            else
            {
                LoadScene(EntryScene);
            }
        }

        public  AsyncOperation LoadSceneAsync()
        {
            return SceneTools.LoadSceneAsync(LevelModel.GetByType(CurrentScene));
        }

        public void LoadScene(SceneType sceneType)
        {
            PreviousScene = CurrentScene;
            CurrentScene = sceneType;
            SceneUnloadedHandler?.Invoke(PreviousScene);
            SceneLoadedHandler?.Invoke(sceneType);
            SceneTools.LoadScene(LevelModel.GetByType(SceneType.Loading));
        }
    }

    public interface ILevelService
    {
         void LoadScene(SceneType sceneType);
         AsyncOperation LoadSceneAsync();
         SceneType CurrentScene { get;  }
    }

    public enum SceneType
    {
        Unset = -1,
        Loading = 0,
        Example = 9999,
    }
}