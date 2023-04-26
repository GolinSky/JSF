namespace CodeFramework
{
    public abstract class EntityFactory<TEntity> : Factory<TEntity, string>
        where TEntity:IEntity
    {
  
    }
}