using System;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Andead.UnitOfWork.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IQueryBuilder<TEntity> Get<TEntity>() where TEntity : class;
        EntityEntry<TEntity> Add<TEntity>(TEntity item) where TEntity : class;
        void Remove<TEntity>(TEntity item) where TEntity : class;
        void Commit();
    }
}
