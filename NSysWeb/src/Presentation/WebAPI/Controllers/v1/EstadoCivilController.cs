using Application.Features.EstadosCiviles.Commands.ActualizarEstadosCivilesCommand;
using Application.Features.EstadosCiviles.Commands.EliminarEstadosCivilesCommand;
using Application.Features.EstadosCiviles.Commands.InsertarEstadosCivilesCommand;
using Application.Features.EstadosCiviles.Queries.ListarEstadosCivilesQuery;
using Application.Features.EstadosCiviles.Queries.ObtenerXIdEstadoCivil;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace WebAPI.Controllers.v1
{
    [ApiVersion("1.0")]
    public class EstadoCivilController : BaseApiController
    {
        [HttpGet("{id:int}",Name = "ObtenerXId")]
        public async Task<ActionResult> GetByid(int id)
        {
            return Ok(await Mediator.Send(new ObtenerXIdEstadoCivilQuery { IdEstadoCivil = id }));
        }

        [HttpGet(Name = "ListarXParametros")]
        public async Task<ActionResult> Get([FromQuery] ListarEstadosCivilesXParametro parametros)
        {
            return Ok(await Mediator.Send(new ListarEstadosCivilesQuery
            {
                NumeroDePagina = parametros.NumeroDePagina,
                RegistroXPagina = parametros.RegistrosXPagina,
                Descripcion = parametros.Descripcion,
                Estatus = parametros.Estatus
            }));
        }

        [HttpPost(Name = "InsertaEstadoCivil")]
        public async Task<IActionResult> Post(InsertarEstadoCivilCommand insertarEstadoCivilCommand)
        {
            return Ok(await Mediator.Send(insertarEstadoCivilCommand));
        }

        [HttpDelete("{id:int}", Name = "EliminaEstadoCivil_Fisico")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await Mediator.Send(new EliminarEstadoCivilCommand { IdEstadoCivil = id} ));
        }

        [HttpPut(Name = "ActulizaEstadoCivil")]
        public async Task<ActionResult> Update(ActualizarEstadoCivilCommand actualizarEstadoCivilCommand)
        {
            return Ok(await Mediator.Send(actualizarEstadoCivilCommand));
        }
    }
}
