namespace CodeFramework.Runtime
{
    public interface IComponentObserver
    {
        
    }
    
    public interface IComponent: IComponentObserver
    {

    }

    public abstract class Component : IComponent
    {

    }

    public abstract class Component<TEntity> : Component 
        where TEntity:IEntity
    {
        public abstract void Init(TEntity entity);
        public abstract void Release();
    }
}