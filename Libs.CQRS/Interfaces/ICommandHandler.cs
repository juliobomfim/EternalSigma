using System.Threading;
using System.Threading.Tasks;

namespace Libs.CQRS.Interfaces
{
    public interface ICommandHandler { }

    public interface ICommandHandler<TRequest> : ICommandHandler where TRequest : class, ICommandInput
    {
        Task<ICommandOutput> Handle(TRequest command);
    }

    public interface ICancellableCommandHandler<TRequest> : ICommandHandler where TRequest : class, ICommandInput
    {
        Task<ICommandOutput> Handle(TRequest command, CancellationToken cancellationToken = default);
    }
}
