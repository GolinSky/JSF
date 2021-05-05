using System;
using Core.BaseServices.SceneService.Service;
using Core.Patterns.MVC.Model;
using Core.Utils.Array;
using Core.Utils.Scene;
using UnityEngine;

#pragma warning disable 0649

namespace Core.BaseServices.SceneService.Model
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
            SceneType sceneType = BaseServices.SceneService.Service.SceneService.EntryScene;
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
