using jbDEV_Eternal.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace jbDEV_Eternal.Domain.Contracts.Repositories
{
    public interface IRepository
    {
        Task AddAsync<T>(T entity, CancellationToken cancellationToken = default) where T : Entity;
        void Remove<T>(T entity) where T : Entity;
        Task<T> GetByIdAsync<T>(Guid id, CancellationToken cancellationToken = default) where T : Entity;
        Task<T> GetFirstOrDefaultAsync<T>(Expression<Func<T, bool>> expression, CancellationToken cancellationToken = default) where T : Entity;
        Task<List<T>> GetListAsync<T>(Expression<Func<T, bool>> expression, CancellationToken cancellationToken = default) where T : Entity;

    }
}
