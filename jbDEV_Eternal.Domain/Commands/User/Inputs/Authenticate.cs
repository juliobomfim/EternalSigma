using Libs.CQRS.Interfaces;

namespace jbDEV_Eternal.Domain.Commands.User.Inputs
{
    public class Authenticate : ICommandInput
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
