using jbDEV_Eternal.Domain.Contracts;
using jbDEV_Eternal.Domain.Models.Output;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace jbDEV_Eternal_API.Abstract
{
    public abstract class EternalApiController : Controller
    {
        private readonly IUow _uow;

        public EternalApiController(IServiceProvider serviceProvider)
        {
            _uow = serviceProvider.GetRequiredService<IUow>();
        }

        public async Task<IActionResult> AsyncExecute<T>(Task<T> task, CancellationToken cancellationToken = default) where T : ApiResponse 
        {
            try
            {
                var response = await task;
                if (response.Type == ResponseType.Success)
                    await _uow.CommitAsync(cancellationToken);

                return Ok(response);
            }catch(Exception ex)
            {
                return BadRequest(ApiResponse.Failure("Ocorreu um erro interno no servidor!", new
                {
                    ex.Message,
                    ex.StackTrace
                }));
            }
        }
    }
}
