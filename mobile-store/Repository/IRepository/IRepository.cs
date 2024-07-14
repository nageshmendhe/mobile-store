namespace mobile_store.Repository.IRepository
{
    public interface IRepository<TEntity> : IDisposable where TEntity : class
    {
        public Task Add(TEntity entity);

        public void Update(TEntity entity);

        public IEnumerable<TEntity> GetAll();

        public TEntity GetById(int id);

        public void Delete(TEntity entity);

        IQueryable<TEntity> Table { get; }
    }
}
