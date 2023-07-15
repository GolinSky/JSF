using CodeFramework.Runtime.Controllers.View;
using UnityEngine;

namespace CodeFramework.Runtime.Controllers.Factory
{
    public class ViewFactory: Factory<ViewBinding, Controller, string>
    {
        public ViewFactory(IRepository<string> repository) : base(repository)
        {
        }

        public override ViewBinding Construct(Controller controller)
        {
            // var bindingPrefab = Repository.Load<ViewBinding>(controller.Id);
            // var binding = Object.Instantiate(bindingPrefab);
            // binding.Init(controller);
            // return binding;
            
            //todo: fix asap
            var bindingPrefab = Repository.Load<GameObject>(controller.Id);
            if (bindingPrefab != null)
            {
                var binding = Object.Instantiate(bindingPrefab).GetComponent<ViewBinding>();
                binding.Init(controller);
                return binding;
            }

            return null;
        }
    }
}