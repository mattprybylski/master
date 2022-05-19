using EF.Business.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF.Business.Base
{
    public class UnitOfWork<TContext> : IUnitOfWork<TContext>
    where TContext : DbContext, IDisposable
    {
        private Dictionary<Type, object> _repositories;
        private Dictionary<Type, object> _asyncRepositories;
        public TContext Context { get; }

        public UnitOfWork(TContext context)
        {
            Context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public IRepository<TEntity> GetRepository<TEntity>() where TEntity : class
        {
            if (_repositories == null) _repositories = new Dictionary<Type, object>();

            var type = typeof(TEntity);
            if (!_repositories.ContainsKey(type)) _repositories[type] = new Repository<TEntity>(Context);
            return (IRepository<TEntity>)_repositories[type];
        }

        public IReadRepository<TEntity> GetReadOnlyRepository<TEntity>() where TEntity : class
        {
            if (_repositories == null) _repositories = new Dictionary<Type, object>();

            var type = typeof(TEntity);
            if (!_repositories.ContainsKey(type)) _repositories[type] = new BaseRepository<TEntity>(Context);
            return (IReadRepository<TEntity>)_repositories[type];
        }

        public IRepositoryAsync<TEntity> GetRepositoryAsync<TEntity>() where TEntity : class
        {
            if (_asyncRepositories == null) _asyncRepositories = new Dictionary<Type, object>();

            var type = typeof(TEntity);
            if (!_asyncRepositories.ContainsKey(type)) _asyncRepositories[type] = new RepositoryAsync<TEntity>(Context);
            return (IRepositoryAsync<TEntity>)_asyncRepositories[type];
        }

        public IReadRepositoryAsync<TEntity> GetReadOnlyRepositoryAsync<TEntity>() where TEntity : class
        {
            if (_asyncRepositories == null) _asyncRepositories = new Dictionary<Type, object>();

            var type = typeof(TEntity);
            if (!_asyncRepositories.ContainsKey(type)) _asyncRepositories[type] = new BaseRepositoryAsync<TEntity>(Context);
            return (IReadRepositoryAsync<TEntity>)_asyncRepositories[type];
        }

        public int Commit<T>( T entity, bool autoHistory = false)
        {
            var entries = Context.ChangeTracker.Entries();
            var blah = Context.Entry(entity);

            var id =  Context.SaveChanges();
            Context.Entry(entity).State = EntityState.Detached;
            return id; 
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public int Commit(bool autoHistory = false)
        {
            throw new NotImplementedException();
        }
    }
}
