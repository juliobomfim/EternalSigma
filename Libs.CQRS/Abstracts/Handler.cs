using Libs.CQRS.Defaults;
using Libs.CQRS.Interfaces;

namespace Libs.CQRS.Abstracts
{
    public abstract class Handler
    {
        public ICommandOutput Success(params string[] messages) => new CommandOutput(true, messages);

        public ICommandOutput Success(object data, params string[] messages) => new CommandOutput(data, true, messages);

        public ICommandOutput Failure(params string[] messages) => new CommandOutput(false, messages);

        public ICommandOutput Failure(object data, params string[] messages) => new CommandOutput(data, false, messages);
    }
}
