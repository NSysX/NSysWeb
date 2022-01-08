using Application.Features.Asentamientos.Commands.ActualizarAsentamientosCommand;
using Application.Features.Asentamientos.Commands.EliminarAsentamientosCommand;
using Application.Features.Asentamientos.Commands.InsertarAsentamientosCommand;
using Application.Features.Asentamientos.Queries.AsentamientosXParametros;
using Application.Features.Asentamientos.Queries.AsentamientoXId;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace WebAPI.Controllers.v1
{
    [ApiVersion("1.0")]
    public class AsentamientoController : BaseApiController
    {
        [HttpGet(Name = "AsentamientosXParametros")]
        public async Task<ActionResult> GetAsentamientosXParametros([FromQuery] AsentamientoParametros parametros)
        {
            return Ok(await Mediator.Send(new AsentamientosXParametrosQuery
            {
                NumeroDePagina = parametros.NumeroDePagina,
                RegistrosXPaginas = parametros.RegistrosXPagina,
                Nombre = parametros.Nombre,
                CodigoPostal = parametros.CodigoPostal
            }));
        }

        [HttpGet("{id:int}", Name = "ObtenerAsentamientoXId")]
        public async Task<ActionResult> GetAsentamientoXId(int id)
        {
            return Ok(await Mediator.Send(new AsentamientoXIdQuery { IdAsentamiento = id }));
        }

        [HttpPost(Name = "InsertarAsentamiento")]
        public async Task<ActionResult> PostAsentamiento(InsertarAsentamientoCommand insertar)
        {
            return Ok(await Mediator.Send(insertar));
        }

        [HttpPut(Name = "ActualizarAsentamiento")]
        public async Task<ActionResult> PutAsentamiento(ActualizarAsentamientoCommand actualizar)
        {
            return Ok(await Mediator.Send(actualizar));
        }

        [HttpDelete("{id:int}", Name = "EliminarAsentamiento")]
        public async Task<ActionResult> DeleteAsentamiento(int id)
        {
            return Ok(await Mediator.Send(new EliminarAsentamientoCommand { IdAsentamiento = id }));
        }

    }
}
