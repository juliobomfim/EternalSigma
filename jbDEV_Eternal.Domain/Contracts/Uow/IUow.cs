using System.Threading;
using System.Threading.Tasks;

namespace jbDEV_Eternal.Domain.Contracts
{
    public interface IUow
    {
        Task CommitAsync(CancellationToken cancellationToken = default);
    }
}
