namespace KeepHome.Data
{
    using System.Linq;

    public interface IRepository<TEntity>
          where TEntity : class
    {
        IQueryable<TEntity> All();

        void Add(TEntity entity);

        void Delete(TEntity entity);

        int SaveChanges();
    }
}