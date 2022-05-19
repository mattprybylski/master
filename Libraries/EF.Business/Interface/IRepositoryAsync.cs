using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EF.Business.Interface
{
    public interface IRepositoryAsync<T> : IReadRepositoryAsync<T>, IDisposable where T : class
    {
        ValueTask<EntityEntry<T>> InsertAsync(T entity,
            CancellationToken cancellationToken = default);
        Task InsertAsync(params T[] entities);
        Task InsertAsync(IEnumerable<T> entities,
            CancellationToken cancellationToken = default);

        void Detach(T entity); 
        T Update(T entity);
        void Update(params T[] entities);
        void Update(IEnumerable<T> entities);

        void Delete(T entity);
        void Delete(params T[] entities);
        void Delete(IEnumerable<T> entities);

    }
}
