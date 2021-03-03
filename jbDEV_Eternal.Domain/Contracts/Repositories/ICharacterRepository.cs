using jbDEV_Eternal.Domain.Entities;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace jbDEV_Eternal.Domain.Contracts.Repositories
{
    public interface ICharacterRepository : IRepository<Character>
    {
        Task<List<Character>> SelectByNameAsync(string name, CancellationToken cancellationToken = default);
    }
}
