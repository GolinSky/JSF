using UnityEngine;

namespace CodeFramework
{
    public interface IFactory<out TEntity>
    {
        TEntity Construct();
    }
    public interface IFactory<out TEntity, in TKey> 
    {
        TEntity Construct(TKey key);
    }

    public abstract class Factory<TEntity, TKey> : IFactory<TEntity, TKey> where TEntity : Object
    {
        protected IRepository<TKey> Repository { get; }

        protected Factory(IRepository<TKey> repository)
        {
            Repository = repository;
        }

        public abstract TEntity Construct(TKey key);
    }
    
    public abstract class Factory<TEntity, TKey, TRepositoryKey> : IFactory<TEntity, TKey> where TEntity : Object
    {
        protected IRepository<TRepositoryKey> Repository { get; }

        protected Factory(IRepository<TRepositoryKey> repository)
        {
            Repository = repository;
        }

        public abstract TEntity Construct(TKey key);
    }
}