using CodeFramework.Runtime.Controller;

namespace CodeFramework.Runtime.View
{
    public  class View<TIViewController> : ViewBinding<TIViewController>
        where TIViewController : IViewController
    {
        public void Update()
        {
            OnUpdate();
        }

        public void Start()
        {
            OnInit();
        }

        public void OnDestroy()
        {
            OnRelease();
        }
        
        protected virtual void OnInit(){}
        protected virtual void OnUpdate(){}
        protected virtual void OnRelease(){}
    }
}

