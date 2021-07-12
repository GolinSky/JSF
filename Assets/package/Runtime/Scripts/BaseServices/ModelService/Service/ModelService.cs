using UnityEngine.Package.Runtime.Scripts.BaseServices.ModelService.Model;
using UnityEngine.Package.Runtime.Scripts.ConfigurationService;
using UnityEngine.Package.Runtime.Scripts.Patterns.MVC.Model;

#pragma warning disable 0649

namespace UnityEngine.Package.Runtime.Scripts.BaseServices.ModelService.Service
{
    public class ModelService:IModelService
    {
        private  GameModel gameModel;

        private  GameModel GameModel
        {
            get
            {
                if (gameModel == null)
                {
                    gameModel = Resources.Load<GameModel>(Configuration.GameModelPath);// todo: create configuration class for storing const data 
                }

                return gameModel;
            }
        }
        public  T GetModel<T>() where T : IModel
        {
            return GameModel.GetModel<T>();
        }
    }

    public interface IModelService
    {
        T GetModel<T>() where T : IModel;
    }
    
}

