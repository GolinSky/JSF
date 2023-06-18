using CodeFramework.Runtime.View;
using UnityEngine;

namespace CodeFramework.Runtime.Factory
{
    public class ViewFactory: Factory<ViewBinding, Controller, string>
    {
        public ViewFactory(IRepository<string> repository) : base(repository)
        {
        }

        public override ViewBinding Construct(Controller controller)
        {
            var bindingPrefab = Repository.Load<ViewBinding>(controller.Id);
            var binding = Object.Instantiate(bindingPrefab);
            binding.Init(controller);
            return binding;
        }
    }
}