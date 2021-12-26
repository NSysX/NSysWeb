using Application.Features.Telefonos.Commands.ActualizarTelefonosCommand;
using Application.Features.Telefonos.Commands.EliminarTelefonosCommand;
using Application.Features.Telefonos.Commands.InsertarTelefonosCommand;
using Application.Features.Telefonos.Queries.ListarTelefonosQuery;
using Application.Features.Telefonos.Queries.ObtenerXIdTelefonoQuery;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace WebAPI.Controllers.v1
{
    [ApiVersion("1.0")]
    public class TelefonoController : BaseApiController
    {
        [HttpGet(Name = "ListarTelefonos")]
        public async Task<ActionResult> GetListarTelefonos([FromQuery] TelefonosParametros telefonos)
        {
            return Ok(await Mediator.Send(new ListarTelefonosQuery
            {
                NumeroDePagina = telefonos.NumeroDePagina,
                RegistrosXPagina = telefonos.RegistrosXPagina,
                Estatus = telefonos.Estatus,
                CodigoPais = telefonos.CodigoPais,
                Numero = telefonos.Numero
            }));
        }

        [HttpGet("{id:int}", Name = "ObtenerXIdTelefono")]
        public async Task<ActionResult> GetByIdTelefono(int id)
        {
            return Ok(await Mediator.Send(new ObtenerXIdTelefonoQuery { IdTelefono = id }));
        }

        [HttpPost(Name = "InsertarTelefono")]
        public async Task<ActionResult> PostTelefono(InsertarTelefonoCommand insertar)
        {
            return Ok(await Mediator.Send(insertar));
        }

        [HttpPut(Name = "ActualizarTelefono")]
        public async Task<ActionResult> UpdateTelefono(ActualizarTelefonoCommand actualizar)
        {
            return Ok(await Mediator.Send(actualizar));
        }

        [HttpDelete("{id:int}", Name = "EliminarTelefono")]
        public async Task<ActionResult> DeleteTelefono(int id)
        {
            return Ok(await Mediator.Send(new EliminarTelefonoCommand { IdTelefono = id }));
        }
    }
}
