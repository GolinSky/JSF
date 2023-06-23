namespace CodeFramework
{
    public interface IHub<TEntity> where TEntity:IEntity
    {
        TEntity Get<TEntity>();
        void Remove(TEntity entity);

    }
}