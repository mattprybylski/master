using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MP.EF.Business.Interfaces
{
    public interface IRepository<T> : IReadRepository<T>, IDisposable where T : class
    {
        T Insert(T entity);
        void Insert(params T[] entities);
        void Insert(IEnumerable<T> entities);

        T Update(T entity);
        void Update(params T[] entities);
        void Update(IEnumerable<T> entities);

        void Delete(T entity);
        void Delete(params T[] entities);
        void Delete(IEnumerable<T> entities);

    }
}
