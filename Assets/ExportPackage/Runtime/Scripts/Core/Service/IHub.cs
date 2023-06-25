namespace CodeFramework
{
    public interface IHub<TEntity>
    {
        TEntity Get<TEntity>();
         
        void Remove(TEntity entity);

    }
}