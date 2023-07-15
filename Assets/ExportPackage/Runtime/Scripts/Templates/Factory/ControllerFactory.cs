using System;
using CodeFramework.Runtime.Controllers.BaseServices;

namespace CodeFramework.Runtime.Controllers.Factory
{
    public class ControllerFactory<TController>:IFactory<TController, IGameService> 
        where TController:Controller
    {
        public TController Construct(IGameService gameService) 
        {
            var controller = Activator.CreateInstance(typeof(TController), gameService);
            return (TController)controller;
        }
    }
}