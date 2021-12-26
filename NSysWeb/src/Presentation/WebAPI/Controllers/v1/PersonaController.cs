using Application.Features.Personas.Commands.ActualizarPersonasCommand;
using Application.Features.Personas.Commands.EliminarPersonasCommand;
using Application.Features.Personas.Commands.InsertarPersonasCommand;
using Application.Features.Personas.Queries.ListarPersonasXParametros;
using Application.Features.Personas.Queries.ObtenerXIdPersona;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace WebAPI.Controllers.v1
{
    [ApiVersion("1.0")]
    public class PersonaController : BaseApiController
    {
        [HttpGet(Name = "ListarPersonasXParametros")]
        public async Task<ActionResult> GetListarPersonasXParametros([FromQuery] ListarPersonasParametros listar)
        {
            return Ok(await Mediator.Send(new ListarPersonasXParametrosQuery
            {
                NumeroDePagina = listar.NumeroDePagina,
                RegistrosXPagina = listar.RegistrosXPagina,
                Estatus = listar.Estatus,
                ApellidoPaterno = listar.ApellidoPaterno,
                ApellidoMaterno = listar.ApellidoMaterno,
                Nombres = listar.Nombres
            }));
        }

        [HttpGet("{id:int}",Name = "ObtenerXIdPersona")]
        public async Task<ActionResult> GetXIdPersona(int id)
        {
            return Ok(await Mediator.Send(new ObtenerXIdPersonaQuery { IdPersona = id}));
        }

        [HttpPost(Name = "InsertarPersona")]
        public async Task<ActionResult> PostPersona(InsertarPersonaCommand insertar)
        {
            return Ok(await Mediator.Send(insertar));
        }

        [HttpDelete("{id:int}", Name = "BorrarPersona")]
        public async Task<ActionResult> DeletePersona(int id)
        {
            return Ok(await Mediator.Send(new EliminarPersonaCommand { IdPersona = id }));
        }

        [HttpPut(Name = "ActualizarPersona")]
        public async Task<ActionResult> PutPersona(ActualizarPersonaCommand actualizar)
        {
            return Ok(await Mediator.Send(actualizar));
        }
    }
}