using Application.Features.Direcciones.Commands.ActualizarDireccionesCommand;
using Application.Features.Direcciones.Commands.EliminarDireccionesCommand;
using Application.Features.Direcciones.Commands.InsertarDireccionesCommand;
using Application.Features.Direcciones.Queries.DireccionesXParametros;
using Application.Features.Direcciones.Queries.DireccionXId;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace WebAPI.Controllers.v1
{
    [ApiVersion("1.0")]
    public class DireccionController : BaseApiController
    {
        [HttpGet(Name = "DireccionesXParametros")]
        public async Task<ActionResult> GetDirecciones([FromQuery] DireccionesParametros parametros)
        {
            return Ok(await Mediator.Send(new DireccionesXParametrosQuery
            {
                NumeroDePagina = parametros.NumeroDePagina,
                RegistrosXPagina = parametros.RegistrosXPagina,
                Calle = parametros.Calle
            }));
        }

        [HttpGet("{id:int}",Name = "DireccionXId")]
        public async Task<ActionResult> GetDireccionXId(int id)
        {
            return Ok(await Mediator.Send(new DireccionXIdQuery { IdDireccion = id }));
        }

        [HttpPost(Name = "InsertarDireccion")]
        public async Task<ActionResult> PostDireccion(InsertarDireccionCommand direccion)
        {
            return Ok(await Mediator.Send(direccion));
        }

        [HttpPut(Name = "ActualizarDireccion")]
        public async Task<ActionResult> PutDireccion(ActualizarDireccionCommand actualizar)
        {
            return Ok(await Mediator.Send(actualizar));
        }

        [HttpDelete("{id:int}", Name = "DeleteDireccion")]
        public async Task<ActionResult> DeleteDireccion(int id)
        {
            return Ok(await Mediator.Send(new EliminarDireccionCommand { IdDireccion = id }));
        }
    }
}
