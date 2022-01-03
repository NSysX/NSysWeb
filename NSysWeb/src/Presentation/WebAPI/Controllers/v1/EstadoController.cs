using Application.Features.Estados.Commands;
using Application.Features.Estados.Commands.ActualizarEstadosCommand;
using Application.Features.Estados.Commands.EliminarEstadosCommand;
using Application.Features.Estados.Queries.ListarEstados;
using Application.Features.Estados.Queries.ObtenerXIdEstados;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace WebAPI.Controllers.v1
{
    [ApiVersion("1.0")]
    public class EstadoController : BaseApiController
    {
        [HttpGet(Name = "ListarEstado")]
        public async Task<ActionResult> GetEstados([FromQuery] EstadosParametros estadosParametros)
        {
            return Ok(await Mediator.Send(new ListarEstadosQuery
            {
                NumeroDePagina = estadosParametros.NumeroDePagina,
                RegistrosXPagina = estadosParametros.RegistrosXPagina,
                Estatus = estadosParametros.Estatus,
                Nombre = estadosParametros.Nombre,
                VariableAbrev = estadosParametros.VariableAbrev
            }));
        }

        [HttpGet("{id:int}", Name = "ObtenerXIdEstado")]
        public async Task<ActionResult> GetXIdEstado(int id)
        {
            return Ok(await Mediator.Send(new ObtenerXIdEstadoQuery { IdEstado = id}));
        }

        [HttpPost(Name = "InsertarEstado")]
        public async Task<ActionResult> PostEstado(InsertarEstadoCommand estado)
        {
            return Ok(await Mediator.Send(estado));
        }

        [HttpPut(Name = "ActualizarEstado")]
        public async Task<ActionResult> PutEstado(ActualizarEstadoCommand actualizarEstado)
        {
            return Ok(await Mediator.Send(actualizarEstado));
        }

        [HttpDelete("{id:int}", Name = "EliminarEstado")]
        public async Task<ActionResult> DeleteEstado(int id)
        {
            return Ok(await Mediator.Send(new EliminarEstadoCommand { IdEstado = id }));
        }
    }
}
