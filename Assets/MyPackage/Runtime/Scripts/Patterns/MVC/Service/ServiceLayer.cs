using EventHandlerUtils;
using UnityEngine.MyPackage.Runtime.Scripts.BaseServices.ModelService.Service;
using UnityEngine.MyPackage.Runtime.Scripts.BaseServices.SceneService.Service;
using UnityEngine.MyPackage.Runtime.Scripts.Patterns.MVC.Model;

namespace UnityEngine.MyPackage.Runtime.Scripts.Patterns.MVC.Service
{
    public abstract class ServiceLayer<MODEL, DTO, CONTEXT> : ServiceLayer<DTO,CONTEXT> where MODEL : IModel
    {
        //todo: impl class must store additional methods and some needed state for other modules
        private MODEL model;

        protected MODEL Model
        {
            get
            {
                if (model == null)
                {
                    model = modelService.GetModel<MODEL>();
                }

                return model;
            }
        }

        protected ServiceLayer(IModelService modelService) : base(modelService)
        {
        }
    }
    
    public abstract class ServiceLayer<Dto, Context> : BaseServiceLayer
    {
        public override SceneType ResetScene => SceneType.Unset;

        //todo: abstract getter on some scene reset 
        //todo: impl class must store additional methods and some needed state for other modules
        protected Dto dto;


        public abstract Context GetContext();

        public virtual void UpdateDto(Dto dto)
        {
            this.dto = dto;
            DtoHandler.Invoke();
        }

        public override void Reset()
        {
            DtoHandler = new Handler();
        }

        public override bool IsInited => dto != null;

        protected ServiceLayer(IModelService modelService) : base(modelService)
        {
        }
    }

    public interface IServiceLayer<Dto, Context> 
    {
        Context GetContext();
        void UpdateDto(Dto dto);
    }
}