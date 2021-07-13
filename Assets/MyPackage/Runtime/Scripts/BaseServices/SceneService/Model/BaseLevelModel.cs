using UnityEngine.MyPackage.Runtime.Scripts.Patterns.MVC.Model;
using UnityEngine.MyPackage.Runtime.Scripts.Utils.Array;
using UnityEngine.MyPackage.Runtime.Scripts.Utils.Scene;

namespace UnityEngine.MyPackage.Runtime.Scripts.BaseServices.SceneService.Model
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