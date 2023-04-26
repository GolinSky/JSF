namespace CodeFramework
{
    public abstract class EntityFactory<TEntity> : Factory<TEntity, string>
    {
        protected IRepository<TEntity, string> Repository { get; }
        protected EntityFactory(IRepository<TEntity, string> repository)
        {
            Repository = repository;
        }
    }
}