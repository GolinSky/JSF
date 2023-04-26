namespace CodeFramework
{
    public abstract class EntityFactory<TEntity> : Factory<TEntity, string>
        where TEntity:IEntity
    {
        protected IRepository<TEntity, string> Repository { get; }
        protected EntityFactory(IRepository<TEntity, string> repository)
        {
            Repository = repository;
        }
    }
}