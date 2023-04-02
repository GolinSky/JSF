using System;
using CodeFramework.Examples.ServerConfigurationEntity.Model;
using CodeFramework.Runtime.BaseServices.ModelService.Service;
using CodeFramework.Runtime.Proxy;
using Zenject;

namespace CodeFramework.Examples.RestTemplateEntity.MiddleWare
{
    public class RestTemplateMiddleWare : IServerModelMiddleWare
    {
        [Inject]
        private readonly IModelService modelService;
        public Uri ServerUri => modelService.GetModel<ServerConfigurationsModel>().GetById(ServerName.Default).Uri;


    }
}
