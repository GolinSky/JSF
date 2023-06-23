namespace CodeFramework
{
    public interface IHub<TEntity> where TEntity:IEntity
    {
        TEntity Get<TEntity>(string id);
        void Remove(TEntity entity);

    }
}