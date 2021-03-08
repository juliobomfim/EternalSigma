using jbDEV_Eternal.Domain.Entities;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace jbDEV_Eternal.Domain.Contracts.Repositories
{
    public interface IRepository<T> where T : Entity
    {
        Task AddAsync(T entity, CancellationToken cancellationToken = default);
        void RemoveAsync(T entity);
        Task<T> GetAsync(Guid id, CancellationToken cancellationToken = default);
    }
}
