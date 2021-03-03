using jbDEV_Eternal.Domain.Contracts.Repositories;
using jbDEV_Eternal.Domain.Contracts.Services;
using jbDEV_Eternal.Domain.Models.Input;
using jbDEV_Eternal_API.Abstract;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace jbDEV_Eternal.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/v1/[controller]")]
    public class CharacterController : EternalApiController
    {

        private readonly ICharacterService _characterService;
        private readonly ICharacterRepository _characterRepository;

        public CharacterController(ICharacterService characterService, ICharacterRepository characterRepository, IServiceProvider serviceProvider) : base(serviceProvider)
        {
            _characterService = characterService;
            _characterRepository = characterRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] string name, CancellationToken cancellationToken) => Ok(await _characterRepository.SelectByNameAsync(name, cancellationToken));

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] RegisterCharacterModel model, CancellationToken cancellationToken) => await AsyncExecute(_characterService.CreateCharacterAsync(model, cancellationToken), cancellationToken);
    }
}
