using Microsoft.EntityFrameworkCore;
using mobile_store.Models;
using mobile_store.Repository.IRepository;

namespace mobile_store.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : BaseEntityModel, new()
    {
        private readonly MobilePhoneStoreContext _dbContext;

        private bool disposed = false;

        /// <summary>
        /// The database set
        /// </summary>
        protected DbSet<TEntity> DbSet;
        public Repository(MobilePhoneStoreContext dbContext)
        {
            _dbContext = dbContext;
            DbSet = this._dbContext.Set<TEntity>();
        }
        public async Task Add(TEntity entity)
        {
            DbSet.Add(entity);
            Save();
        }

        public void Delete(TEntity entity)
        {
            DbSet?.Remove(entity);
            Save();
        }

        public IEnumerable<TEntity> GetAll()
        {
            return DbSet;
        }

        public TEntity GetById(int id)
        {
            return DbSet.FirstOrDefault(x => x.Id == id) ?? throw new InvalidOperationException("Entity not found");
        }

        public void Update(TEntity entity)
        {
            DbSet.Update(entity);
            Save();
        }

        private void Save()
        {
            this._dbContext.SaveChanges();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    //Cleanup
                    _dbContext.Dispose();
                }
            }

            this.disposed = true;
        }
        public virtual IQueryable<TEntity> Table
        {
            get
            {
                return this.DbSet;
            }
        }
    }
}
