using System;
using Microsoft.EntityFrameworkCore;
using Andead.UnitOfWork.Interfaces;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Andead.UnitOfWork
{
    public abstract class UnitOfWork : DbContext, IUnitOfWork
    {
        public UnitOfWork() : base() { }

        public UnitOfWork(DbContextOptions options) : base(options) { }

        protected abstract override void OnConfiguring(DbContextOptionsBuilder options);

        protected abstract override void OnModelCreating(ModelBuilder modelBuilder);

        public void Commit()
        {
            try
            {
                SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception($"Can't save entity: {ex.Message}");
            }
        }

        public virtual new EntityEntry<TEntity> Add<TEntity>(TEntity item) where TEntity : class
        {
            return Set<TEntity>().Add(item);
        }

        public IQueryBuilder<TEntity> Get<TEntity>() where TEntity : class
        {
            return new QueryBuilder<TEntity>(Set<TEntity>());
        }

        public virtual new void Remove<TEntity>(TEntity item) where TEntity : class
        {
            Set<TEntity>().Attach(item);
            Set<TEntity>().Remove(item);
        }
    }
}
