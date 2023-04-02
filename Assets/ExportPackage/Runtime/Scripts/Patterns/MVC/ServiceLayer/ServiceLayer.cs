using System;
using UnityEngine.MyPackage.Runtime.Scripts.BaseServices.EventEntity;
using UnityEngine.MyPackage.Runtime.Scripts.BaseServices.ModelService.Service;
using UnityEngine.MyPackage.Runtime.Scripts.Patterns.MVC.Model;

namespace UnityEngine.MyPackage.Runtime.Scripts.Patterns.MVC.ServiceLayer
{
    public abstract class ServiceLayer<Dto, Context>:IContextLayer<Context>, IDtoLayer<Dto>
    {
        protected readonly IModelService ModelService;
        protected Dto dto;
        protected CleverEvent<Context> CleverEvent { get; } = new CleverEvent<Context>();

        protected ServiceLayer(IModelService modelService)
        {
            ModelService = modelService;
        }
        
        protected abstract Context GetContext();

        public bool HasContext(ref Context context)
        {
            if (dto != null)
            {
                context = GetContext();
                return true;
            }
            return false;
        }

        public void AddListener(Action<Context> action)
        {
            CleverEvent.AddListener(action);
        }

        public void RemoveListener(Action<Context> action)
        {
            CleverEvent.RemoveListener(action);
        }

        public void Reset()
        {
            CleverEvent.Reset();
        }

        public void UpdateDto(Dto dto)
        {
            if(dto == null) return;

            this.dto = dto;
            CleverEvent.Invoke(GetContext());
        }
    }

    public abstract class ServiceLayer<Dto, Context, MODEL> :ServiceLayer<Dto, Context> where MODEL : IModel
    {
        private MODEL model;

        protected MODEL Model
        {
            get
            {
                if (model == null)
                {
                    model = ModelService.GetModel<MODEL>();
                }

                return model;
            }
        }

        protected ServiceLayer(IModelService modelService) : base(modelService)
        {
        }
    }

    public interface IContextLayer<Context>
    {
         bool HasContext(ref Context context);
         void AddListener(Action<Context> action);
         void RemoveListener(Action<Context> action);
    }

    public interface IDtoLayer<Dto>
    {
        void UpdateDto(Dto dto);
    }

}
