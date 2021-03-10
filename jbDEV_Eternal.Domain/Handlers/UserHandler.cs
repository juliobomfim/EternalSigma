using jbDEV_Eternal.Domain.Commands.User.Inputs;
using jbDEV_Eternal.Domain.Contracts.Repositories;
using jbDEV_Eternal.Domain.Entities;
using jbDEV_Eternal.Domain.Shared.Crypt;
using Libs.CQRS.Defaults;
using Libs.CQRS.Interfaces;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Text;
using jbDEV_Eternal.Domain.Constants;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;

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

            if (Crypt.ValidateCryptPass(user.Password) is not string encryptedPassword)
                return CommandOutput.Failure("Incorrect Email/Password credentials...");

            if (encryptedPassword != command.Password)
                return CommandOutput.Failure("Incorrect Email/Password credentials...");

            var mJwt = new JwtSecurityTokenHandler();
            var symmetricKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(AuthenticationConfig.CryptKey));
            var credencials = new SigningCredentials(symmetricKey, SecurityAlgorithms.HmacSha256Signature);
            var expireTime = DateTime
                .UtcNow
                .AddHours(8);

            var descritorToken = new SecurityTokenDescriptor
            {
                Issuer = AuthenticationConfig.Issuer,
                Audience = AuthenticationConfig.Audience,
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Name)
                }),
                Expires = expireTime,
                SigningCredentials = credencials
            };

            var seguracaToken = mJwt
                .CreateJwtSecurityToken(descritorToken);

            var token = mJwt
                .WriteToken(seguracaToken);

            return CommandOutput.Ok(new
            {
                user.Name,
                Token = new
                {
                    Expiracao = expireTime.Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds,
                    Valor = token
                }
            }, "Login successfully!!");
        }
    }
}
