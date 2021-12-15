using Application.Features.SysDominiosCorreos.Commands.ActualizarSysDominiosCorreosCommand;
using Application.Features.SysDominiosCorreos.Commands.EliminarSysDominiosCorreosCommand;
using Application.Features.SysDominiosCorreos.Commands.InsertarSysDominiosCorreosCommand;
using Application.Features.SysDominiosCorreos.Queries.ListarSysDominiosCorreosQuery;
using Application.Features.SysDominiosCorreos.Queries.ObtenerXIdSysDominioCorreoQuery;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace WebAPI.Controllers.v1
{
    [ApiVersion("1.0")]
    public class SysDominioCorreoController : BaseApiController
    {
        [HttpGet(Name = "ListarSysDominiosCorreosParam")]
        public async Task<ActionResult> GetSysDominiosCorreosParam([FromQuery] SysDominiosCorreosParametros sysDominiosCorreosParametros)
        {
            return Ok(await Mediator.Send(new ListarSysDominiosCorreosQuery
            {
                NumeroPagina = sysDominiosCorreosParametros.NumeroDePagina,
                RegistrosXPagina = sysDominiosCorreosParametros.RegistrosXPagina,
                Estatus = sysDominiosCorreosParametros.Estatus,
                Dominio = sysDominiosCorreosParametros.Dominio
            }));
        }

        [HttpGet("{id:int}", Name = "ObtenerXIdSysDominioCorreo")]
        public async Task<ActionResult> GetByIdSysDominioCorreo(int id)
        {
            return Ok(await Mediator.Send(new ObtenerXIdSysDominioCorreoQuery { IdSysDominioCorreo = id }));
        }

        [HttpPost(Name = "InsertarSysDominioCorreo")]
        public async Task<ActionResult> PostSysDominioCorreo(InsertarSysDominioCorreoCommand insertarSysDominioCorreoCommand)
        {
            return Ok(await Mediator.Send(insertarSysDominioCorreoCommand));
        }

        [HttpPut(Name = "ActualizarSysDominioCorreo")]
        public async Task<ActionResult> PutSysDominioCorreo(ActualizarSysDominioCorreoCommand actualizar)
        {
            return Ok(await Mediator.Send(actualizar));
        }

        [HttpDelete("{id:int}", Name = "EliminarSysDominioCorreo")]
        public async Task<ActionResult> DeleteSysDomicionCorreo(int id)
        {
            return Ok(await Mediator.Send(new EliminarSysDominioCorreoCommand { IdSysDominio = id }));
        }
    }
}
