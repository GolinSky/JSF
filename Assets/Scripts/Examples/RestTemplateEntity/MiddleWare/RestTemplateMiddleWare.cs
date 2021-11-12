using System;
using UnityEngine.Examples.ServerConfigurationEntity.Model;
using UnityEngine.MyPackage.Runtime.Scripts.BaseServices.ModelService.Service;
using UnityEngine.MyPackage.Runtime.Scripts.Patterns.Proxy;
using Zenject;

namespace UnityEngine.Examples.RestTemplateEntity.MiddleWare
{
    public class RestTemplateMiddleWare : IServerModelMiddleWare
    {
        [Inject]
        private readonly IModelService modelService;
        public Uri ServerUri => modelService.GetModel<ServerConfigurationsModel>().GetById(ServerName.Default).Uri;


    }
}
