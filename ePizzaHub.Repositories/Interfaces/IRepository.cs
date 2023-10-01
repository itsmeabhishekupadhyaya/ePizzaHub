

namespace ePizzaHub.Repositories.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> GetAll();
        IEnumerable<TEntity> Find(object id);
        void Add(TEntity entity);
        void Update(TEntity entity);
        void Remove(TEntity entity);
        void Delete(object id);
        int SaveChanges();

    }
}
