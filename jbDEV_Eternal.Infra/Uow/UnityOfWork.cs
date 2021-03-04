using jbDEV_Eternal.Domain.Contracts;
using jbDEV_Eternal.Infra.Connections;
using System.Threading;
using System.Threading.Tasks;

namespace jbDEV_Eternal.Infra.Uow
{
    public class UnityOfWork : IUow
    {
        private readonly SqlServerDbContext _dbContext;

        public UnityOfWork(SqlServerDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task CommitAsync(CancellationToken cancellationToken = default) => _dbContext.SaveChangesAsync(cancellationToken);
    }
}
