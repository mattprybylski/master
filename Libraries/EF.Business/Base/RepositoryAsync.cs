using EF.Business.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EF.Business.Base
{
    public class RepositoryAsync<T> : BaseRepositoryAsync<T>, IRepositoryAsync<T> where T : class
    {
        public RepositoryAsync(DbContext context) : base(context)
        {
        }

        #region Insert Functions

        public ValueTask<EntityEntry<T>> InsertAsync(T entity, CancellationToken cancellationToken = default)
        {
            var item = _dbSet.AddAsync(entity, cancellationToken);
            this.Dispose(); 
            return item; 
        }

        public void Detach(T entity)
        {
            _dbContext.Entry<T>(entity).State = EntityState.Detached;
        }

        public Task InsertAsync(params T[] entities)
        {
            return _dbSet.AddRangeAsync(entities);
        }

        public Task InsertAsync(IEnumerable<T> entities, CancellationToken cancellationToken = default)
        {
            return _dbSet.AddRangeAsync(entities, cancellationToken);
        }

        #endregion

        #region Update Functions

        public T Update(T entity)
        {
            return _dbSet.Update(entity).Entity;
        }

        public void Update(params T[] entities)
        {
            _dbSet.UpdateRange(entities);
        }

        public void Update(IEnumerable<T> entities)
        {
            _dbSet.UpdateRange(entities);
        }

        #endregion

        #region Delete Functions

        public void Delete(T entity)
        {
            if (entity != null)
                _dbSet.Remove(entity);
        }

        public void Delete(params T[] entities)
        {
            _dbSet.RemoveRange(entities);
        }

        public void Delete(IEnumerable<T> entities)
        {
            _dbSet.RemoveRange(entities);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        #endregion
    }

}
