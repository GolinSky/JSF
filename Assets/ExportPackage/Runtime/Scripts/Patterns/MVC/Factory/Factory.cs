namespace CodeFramework
{
    public interface IFactory<out TEntity,in TKey>
    {
        TEntity Construct(TKey key);
    }
    
    public abstract class Factory<TEntity,TKey> :IFactory<TEntity, TKey>
    {
        public abstract TEntity Construct(TKey key);
    }
}