using EventHandlerUtils;
using FrameworkCore.BaseServices.ModelService.Service;
using FrameworkCore.BaseServices.SceneService.Service;
using FrameworkCore.Patterns.MVC.Model;

namespace FrameworkCore.Patterns.MVC.Service
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
                    
                    model = ModelService.GetModel<MODEL>();
                }

                return model;
            }
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
    }
}