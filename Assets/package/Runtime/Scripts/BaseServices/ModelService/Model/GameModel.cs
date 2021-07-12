using System;
using System.Collections.Generic;
using UnityEngine.Package.Runtime.Scripts.Patterns.MVC.Dto;
using UnityEngine.Package.Runtime.Scripts.Patterns.MVC.Model;

#pragma warning disable 0649

namespace UnityEngine.Package.Runtime.Scripts.BaseServices.ModelService.Model
{
    [Serializable]
    public class Data<V>:ScriptableObject where V : Dto
    {
        [SerializeField] protected List<ModelPreset> modelList;

        protected Dictionary<Type, IModel> modelDictionary = new Dictionary<Type, IModel>();

        protected Dictionary<Type, IModel> ModelDictionary
        {
            get
            {
                if (modelDictionary == null || modelDictionary.Count == 0)
                {
                    modelList.ForEach(x => modelDictionary.Add(x.GetType(), (IModel) x.Instance));
                }

                return modelDictionary;
            }
        }

        internal T GetModel<T>() where T : IModel
        {
            return (T) ModelDictionary[typeof(T)];
        }
    }

    [Serializable]
    [CreateAssetMenu(fileName = "GameModel", menuName = "Model/GameModel")]
    public class GameModel : Data<Dto>
    {

    }

    [Serializable]
    public class ModelPreset : ModelPreset<ScriptableObject> 
    {
        public new Type GetType() => prefab.GetType();
    }

    [Serializable]
    public class ModelPreset<T> where T : ScriptableObject
    {
        [SerializeField] protected T prefab;
        private T instance;

        public T Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = Object.Instantiate(prefab);
                }

                return instance;
            }
        }
    }
}