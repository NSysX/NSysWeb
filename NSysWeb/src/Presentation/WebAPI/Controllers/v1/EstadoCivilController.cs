using Application.Features.EstadosCiviles.Commands.EliminarEstadosCivilesCommand;
using Application.Features.EstadosCiviles.Commands.InsertarEstadosCivilesCommand;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace WebAPI.Controllers.v1
{
    [ApiVersion("1.0")]
    public class EstadoCivilController : BaseApiController
    {
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
    }
}
