using mobile_store.Models;

namespace mobile_store.Repository.IRepository
{
    public interface IRepository<TEntity> : IDisposable where TEntity : BaseEntityModel
    {
        Task Add(TEntity entity);
        void Delete(TEntity entity);
        IEnumerable<TEntity> GetAll();
        TEntity GetById(int id);
        void Update(TEntity entity);
        IQueryable<TEntity> Table { get; }
    }
}
