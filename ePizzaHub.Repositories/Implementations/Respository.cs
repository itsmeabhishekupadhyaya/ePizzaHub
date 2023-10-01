using ePizzaHub.Repositories.Interfaces;


namespace ePizzaHub.Repositories.Implementations
{
    public class Respository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        public void Add(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(object id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TEntity> Find(object id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TEntity> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Remove(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public int SaveChanges()
        {
            throw new NotImplementedException();
        }

        public void Update(TEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
