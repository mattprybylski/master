using EF.Business.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF.Business.Base
{
    public class Repository<T> : BaseRepository<T>, IRepository<T> where T : class
    {
        public Repository(DbContext context) : base(context)
        {
        }

        #region Insert Functions

        public T Insert(T entity)
        {
            return _dbSet.Add(entity).Entity;
        }

        public void Insert(params T[] entities)
        {
            _dbSet.AddRange(entities);
        }

        public void Insert(IEnumerable<T> entities)
        {
            _dbSet.AddRange(entities);
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

        #endregion

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

    }
}
