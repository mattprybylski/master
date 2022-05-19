using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using MP.EF.Business.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MP.EF.Business.AbstractBase
{
    public class BaseRepositoryAsync<T> : IReadRepositoryAsync<T> where T : class
    {
        protected readonly DbContext _dbContext;
        protected readonly DbSet<T> _dbSet;

        public DbSet<T> GetDbSet()
        {
            return _dbSet;
        }

        public BaseRepositoryAsync(DbContext context)
        {
            _dbContext = context ?? throw new ArgumentException(null, nameof(context));
            _dbSet = _dbContext.Set<T>();
        }

        public async Task<T> GetFirstOrDefaultAsync(Expression<Func<T, bool>> predicate = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null,
            bool enableTracking = false,
            CancellationToken cancellationToken = default)
        {
            IQueryable<T> query = _dbSet;

            if (!enableTracking) query = query.AsNoTracking();

            if (include != null) query = include(query);

            if (predicate != null) query = query.Where(predicate);

            if (orderBy != null) return await orderBy(query).FirstOrDefaultAsync(cancellationToken: cancellationToken);

            return await query.FirstOrDefaultAsync(cancellationToken: cancellationToken);
        }
        public IQueryable<T> GetList(Expression<Func<T, bool>> predicate = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null,
            bool enableTracking = false)
        {
            IQueryable<T> query = _dbSet;

            if (!enableTracking) query = query.AsNoTracking();

            if (include != null) query = include(query);

            if (predicate != null) query = query.Where(predicate);

            return orderBy != null ? orderBy(query) : query;
        }

        public IQueryable<TResult> GetList<TResult>(Expression<Func<T, TResult>> selector,
            Expression<Func<T, bool>> predicate = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null,
            bool enableTracking = false) where TResult : class
        {
            IQueryable<T> query = _dbSet;
            if (!enableTracking) query = query.AsNoTracking();

            if (include != null) query = include(query);

            if (predicate != null) query = query.Where(predicate);

            return orderBy != null ? orderBy(query).Select(selector) : query.Select(selector);
        }
    }
}