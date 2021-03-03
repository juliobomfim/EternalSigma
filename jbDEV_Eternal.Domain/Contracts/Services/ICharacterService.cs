using jbDEV_Eternal.Domain.Models.Input;
using jbDEV_Eternal.Domain.Models.Output;
using System.Threading;
using System.Threading.Tasks;

namespace jbDEV_Eternal.Domain.Contracts.Services
{
    public interface ICharacterService
    {
        Task<ApiResponse> CreateCharacterAsync(RegisterCharacterModel model, CancellationToken cancellationToken = default);
    }
}
