using System;
using UnityEngine.MyPackage.Runtime.Scripts.BaseServices.SceneService.Service;
using UnityEngine.MyPackage.Runtime.Scripts.Patterns.MVC.Model;
using UnityEngine.MyPackage.Runtime.Scripts.Utils.Array;
using UnityEngine.MyPackage.Runtime.Scripts.Utils.Scene;

#pragma warning disable 0649

namespace UnityEngine.MyPackage.Runtime.Scripts.BaseServices.SceneService.Model
{
    [Serializable]
    [CreateAssetMenu(fileName = "LevelModel", menuName = "Model/LevelModel")]
    public class LevelModel : ScriptableObject, IModel
    {
        [SerializeField] private LevelDataList levelDataList;
        public string GetByType(SceneType sceneType)
        {
            return levelDataList.GetById(sceneType).ScenePath;            
        }

        public SceneType GetTypeByName(string sceneName)
        {
            return levelDataList.TryGetSceneType(sceneName);
        }
    }
    #region Generics
    [Serializable]
    public class LevelDataList : DataList<LevelPreset, SceneReference, SceneType>
    {
        public SceneType TryGetSceneType(string sceneName)
        {
            SceneType sceneType = BaseServices.SceneService.Service.LevelService.EntryScene;
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
    [Serializable]
    public class LevelPreset: InternalData<SceneType, SceneReference>{}
    #endregion  
}
