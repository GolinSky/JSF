using System;
using UnityEngine.MyPackage.Runtime.Scripts.BaseServices.SceneService.Model;
using UnityEngine.MyPackage.Runtime.Scripts.BaseServices.SceneService.Service;
using UnityEngine.MyPackage.Runtime.Scripts.Utils.Array;
using UnityEngine.MyPackage.Runtime.Scripts.Utils.Scene;

#pragma warning disable 0649

namespace UnityEngine.Examples.LevelEntity.Model
{
    [Serializable]
    [CreateAssetMenu(fileName = "LevelModel", menuName = "Model/LevelModel")]
    public class LevelModel : BaseLevelModel<SceneType, LevelPreset>
    {
    }

    [Serializable]
    public class LevelPreset : InternalData<SceneType, SceneReference> { }
    
}