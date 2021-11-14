using UnityEngine.Examples.RestTemplateEntity.Context;
using UnityEngine.Examples.RestTemplateEntity.Dto;
using UnityEngine.MyPackage.Runtime.Scripts.BaseServices.ModelService.Service;
using UnityEngine.MyPackage.Runtime.Scripts.Patterns.MVC.ServiceLayer;

namespace UnityEngine.Examples.RestTemplateEntity.ServiceLayer
{
    public class UIdServiceLayer : ServiceLayer<UIdDto,UIdContext>
    {
        public UIdServiceLayer(IModelService modelService) : base(modelService)
        {
        }

        protected override UIdContext GetContext()
        {
            return new UIdContext(dto.uuid);
        }
    }
}