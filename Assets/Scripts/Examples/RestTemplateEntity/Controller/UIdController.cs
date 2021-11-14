using UnityEngine.Examples.RestTemplateEntity.Context;
using UnityEngine.MyPackage.Runtime.Scripts.Patterns.MVC.Controller;
using UnityEngine.MyPackage.Runtime.Scripts.Patterns.MVC.View;

namespace UnityEngine.Examples.RestTemplateEntity.Controller
{
    public class UIdController : Controller<View<string>, UIdContext>
    {
        public UIdController(View<string> view) : base(view)
        {
            
        }

        protected override void HandleServiceLayer(UIdContext context)
        {
            View.SetContext(context.UId);
        }
    }
}
