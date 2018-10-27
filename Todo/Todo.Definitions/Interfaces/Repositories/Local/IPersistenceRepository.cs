namespace NsuGo.Definition.Interfaces.Repositories.Local
{
    public interface IPersistenceRepository<TEntity> where TEntity : class
    {
        void Add(TEntity entity);

        void Update(TEntity entity);

        void Remove(TEntity entity);

        void RemoveAll();
    }
}
