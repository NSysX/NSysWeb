using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[Controller]")]
    public abstract class BaseApiController : ControllerBase
    {
        // para cuando heredes de APIBase controller podamos usar la dependencias de mediatr
        private IMediator _mediatr;
        protected IMediator Mediator => _mediatr ??= HttpContext.RequestServices.GetService<IMediator>(); 
    }
}
