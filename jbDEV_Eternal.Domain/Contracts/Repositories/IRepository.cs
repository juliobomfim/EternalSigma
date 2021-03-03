using jbDEV_Eternal.Domain.Entities;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace jbDEV_Eternal.Domain.Contracts.Repositories
{
    public interface IRepository<T> where T : Entity
    {
        Task InsertAsync(T entity, CancellationToken cancellationToken = default);
        void DeleteAsync(T entity);
        Task<T> RestoreAsync(Guid id, CancellationToken cancellationToken = default);
    }
}
