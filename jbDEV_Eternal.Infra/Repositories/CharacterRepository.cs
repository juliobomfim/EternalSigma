using jbDEV_Eternal.Domain.Contracts.Repositories;
using jbDEV_Eternal.Domain.Entities;
using jbDEV_Eternal.Infra.Connections;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace jbDEV_Eternal.Infra.Repositories
{
    public class CharacterRepository : Repository<Character>, ICharacterRepository
    {
        public CharacterRepository(SqlServerDbContext dataContext) : base(dataContext)
        {
        }

        public Task<List<Character>> GetByNameAsync(string name, CancellationToken cancellationToken = default) => _dataContext.Set<Character>()
            .Where(x => EF.Functions.Like(x.Name, $"%{name}%")).ToListAsync(cancellationToken);
    }
}
