
namespace CodeFramework.Runtime.Controller
{
    public interface IController : IViewController, IEntity
    {
        
    }
    public abstract class Controller: IController
    {
        public virtual string Id => nameof(Controller);
    }
}

