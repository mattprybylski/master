using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MP.EF.Business.Interfaces
{
    public interface IRepositoryFactory
    {
        IRepository<T> GetRepository<T>() where T : class;
        IRepositoryAsync<T> GetReadOnlyRepository<T>() where T : class;
    }
}
