using CodeFramework.Runtime.Model;
using CodeFramework.Runtime.Utils.Array;
using CodeFramework.Runtime.Utils.Scene;

namespace CodeFramework.Runtime.BaseServices.SceneService.Model
{
    public abstract class BaseLevelModel<ID,InternalDataParam> : Model<ID, SceneReference, InternalDataParam> where InternalDataParam : InternalData<ID, SceneReference>
    {
        public string GetByType(ID sceneType)
        {
            return GetById(sceneType).ScenePath;
        }

        public ID GetTypeByName(string sceneName)
        {
            return TryGetSceneType(sceneName);
        }

        private ID TryGetSceneType(string sceneName)
        {
            ID sceneType = default; 
            foreach (var sceneAsset in Dictionary)
            {
                if (sceneAsset.Value.ScenePath.Equals(sceneName))
                {
                    sceneType = sceneAsset.Key;
                    return sceneType;
                }
            }

            return sceneType;
        }
    }
}