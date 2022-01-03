using Application.Features.Direcciones.Commands.InsertarDireccionesCommand;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace WebAPI.Controllers.v1
{
    [ApiVersion("1.0")]
    public class DireccionController : BaseApiController
    {
        [HttpPost(Name = "InsertarDireccion")]
        public async Task<ActionResult> PostDireccion(InsertarDireccionCommand direccion)
        {
            return Ok(await Mediator.Send(direccion));
        }
    }
}
