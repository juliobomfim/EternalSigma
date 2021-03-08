using jbDEV_Eternal.Domain.Commands.User.Inputs;
using jbDEV_Eternal.Domain.Contracts.Repositories;
using jbDEV_Eternal.Domain.Entities;
using Libs.CQRS.Defaults;
using Libs.CQRS.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace jbDEV_Eternal.Domain.Handlers
{
    public class UserHandler : ICancellableCommandHandler<Authenticate>
    {
        private readonly IRepository _rep;

        public UserHandler(IRepository rep)
        {
            _rep = rep;
        }

        public async Task<ICommandOutput> Handle(Authenticate command, CancellationToken cancellationToken = default)
        {
            if (await _rep.GetFirstOrDefaultAsync<User>(user => user.Email == command.Email, cancellationToken) is not User user)
                return CommandOutput.Failure("Incorrect Email/Password credentials...");

            //continue from here...
        }
    }
}
