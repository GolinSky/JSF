using FrameworkCore.Examples.ExampleEntity.View;
using FrameworkCore.Patterns.MVC.Controller;

namespace FrameworkCore.Examples.ExampleEntity.Controller
{
    public class ExampleController : Controller<ExampleView>
    {
        private const string ExampleMessage = "Hello World"; 

     
        public ExampleController(ExampleView view) : base(view)
        {
            view.SetContext(ExampleMessage);
        }

        public override void AddListeners()
        {
        }

        public override void RemoveListeners()
        {
        }
    }
}
