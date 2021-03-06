using Application.Features.EstadosCiviles.Commands.ActualizarEstadosCivilesCommand;
using Application.Features.EstadosCiviles.Commands.EliminarEstadosCivilesCommand;
using Application.Features.EstadosCiviles.Commands.InsertarEstadosCivilesCommand;
using Application.Features.EstadosCiviles.Queries.ListarEstadosCivilesQuery;
using Application.Features.EstadosCiviles.Queries.ObtenerXIdEstadoCivil;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace WebAPI.Controllers.v1
{
    [ApiVersion("1.0")]
    public class EstadoCivilController : BaseApiController
    {

        public EstadoCivilController(ILogger<EstadoCivilController> logger)
        {

        }
        

        [HttpGet("{id:int}",Name = "ObtenerXId")]
        public async Task<ActionResult> GetByid(int id)
        {
            return Ok(await Mediator.Send(new ObtenerXIdEstadoCivilQuery { IdEstadoCivil = id }));
        }

        [HttpGet(Name = "ListarXParametrosEstadosCiviles")]
        public async Task<ActionResult> Get([FromQuery] EstadosCivilesParametros parametros)
        {
            return Ok(await Mediator.Send(new ListarEstadosCivilesQuery
            {
                NumeroDePagina = parametros.NumeroDePagina,
                RegistrosXPagina = parametros.RegistrosXPagina,
                Descripcion = parametros.Descripcion,
                Estatus = parametros.Estatus
            }));
        }

        [HttpPost(Name = "InsertaEstadoCivil")]
        public async Task<IActionResult> Post(InsertarEstadoCivilCommand insertarEstadoCivilCommand)
        {
            return Ok(await Mediator.Send(insertarEstadoCivilCommand));
        }

        [HttpPut(Name = "ActulizaEstadoCivil")]
        public async Task<ActionResult> Update(ActualizarEstadoCivilCommand actualizarEstadoCivilCommand)
        {
            return Ok(await Mediator.Send(actualizarEstadoCivilCommand));
        }

        [HttpDelete("{id:int}", Name = "EliminaEstadoCivil_Fisico")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await Mediator.Send(new EliminarEstadoCivilCommand { IdEstadoCivil = id} ));
        } 
    }
}
