using FrameworkCore.BaseServices.ModelService.Model;
using FrameworkCore.ConfigurationService;
using FrameworkCore.Patterns.MVC.Model;
using UnityEngine;

#pragma warning disable 0649

namespace FrameworkCore.BaseServices.ModelService.Service
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

