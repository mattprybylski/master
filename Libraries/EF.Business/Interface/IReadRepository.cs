using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace EF.Business.Interface
{
    public interface IReadRepository<T> where T : class
    {
        T GetFirstOrDefault(Expression<Func<T, bool>> predicate = null,
           Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
           Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null,
           bool enableTracking = true);

        IQueryable<T> GetList(Expression<Func<T, bool>> predicate = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null,
            bool enableTracking = true);

        IQueryable<TResult> GetList<TResult>(Expression<Func<T, TResult>> selector,
            Expression<Func<T, bool>> predicate = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null,
            bool enableTracking = true) where TResult : class;
    }
}
