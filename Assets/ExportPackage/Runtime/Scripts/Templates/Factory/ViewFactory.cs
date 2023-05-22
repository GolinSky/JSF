using CodeFramework.Runtime.View;

namespace CodeFramework.Runtime.Factory
{
    public class ViewFactory: Factory<ViewBinding, Controller, string>
    {
        public ViewFactory(IRepository<string> repository) : base(repository)
        {
        }

        public override ViewBinding Construct(Controller controller)
        {
            var binding = Repository.Load<ViewBinding>(controller.Id);
            binding.Init(controller);
            return binding;
        }
    }
}