using jbDEV_Eternal.Domain.Contracts.Repositories;
using jbDEV_Eternal.Domain.Entities;
using jbDEV_Eternal.Infra.Connections;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace jbDEV_Eternal.Infra.Repositories
{
    public class Repository<T> : IRepository<T> where T : Entity
    {
        protected SqlServerDbContext _dataContext;

        protected Repository(SqlServerDbContext dataContext)
        {
            _dataContext = dataContext;
        }

        public void RemoveAsync(T entity) => _dataContext.Set<T>().Remove(entity);
        public async Task AddAsync(T entity, CancellationToken cancellationToken = default) => await _dataContext.AddAsync(entity, cancellationToken);
        public async Task<T> GetAsync(Guid id, CancellationToken cancellationToken = default) => await _dataContext.Set<T>().FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
    }
}
