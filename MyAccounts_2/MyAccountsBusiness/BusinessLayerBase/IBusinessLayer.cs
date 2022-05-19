using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MyAccountsBusiness.BusinessLayerBase
{
    public interface IBusinessLayer<T>
    {
        Task<T> SaveAsync(T item);
        Task<T> GetByIdAsync(int Id, CancellationToken cancellationToken = default);
        Task<List<T>> GetAsync(CancellationToken cancellationToken = default);
        void Delete(T item);
    }
}
