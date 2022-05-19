using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MP.EF.Business.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<TEntity> GetRepository<TEntity>() where TEntity : class;
        IReadRepository<TEntity> GetReadOnlyRepository<TEntity>() where TEntity : class;
        IRepositoryAsync<TEntity> GetRepositoryAsync<TEntity>() where TEntity : class;
        IReadRepositoryAsync<TEntity> GetReadOnlyRepositoryAsync<TEntity>() where TEntity : class;

        int Commit(bool autoHistory = false);
    }

    public interface IUnitOfWork<TContext> : IUnitOfWork where TContext : DbContext
    {
        TContext Context { get; }
    }
}
