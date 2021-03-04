using jbDEV_Eternal.Domain.Contracts.Repositories;
using jbDEV_Eternal.Domain.Contracts.Services;
using jbDEV_Eternal.Domain.Entities;
using jbDEV_Eternal.Domain.Models.Input;
using jbDEV_Eternal.Domain.Models.Output;
using System.Threading;
using System.Threading.Tasks;

namespace jbDEV_Eternal.Business.Services
{
    public class CharacterService : ICharacterService
    {
        private readonly ICharacterRepository _rep;

        public CharacterService(ICharacterRepository rep)
        {
            _rep = rep;
        }

        public async Task<ApiResponse> CreateCharacterAsync(RegisterCharacterModel model, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrEmpty(model.Name))
                return ApiResponse.Warning("Character name not provided.");

            if (model.Name.Length > 50)
                return ApiResponse.Warning("Character name cannot contain more than 50 characters.");

            var character = new Character(model.Name, model.HitPoints, model.Strength, model.Defense, model.Intelligence, model.Class);

            await _rep.AddAsync(character, cancellationToken);

            return ApiResponse.Success($"Character {character.Name} successfully creating!", new { character.Id, character.Name });
        }
    }
}
