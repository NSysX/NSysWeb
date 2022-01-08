using Application.Features.Paises.Commands.ActualizarPaisesCommand;
using Application.Features.Paises.Commands.EliminarPaisesCommand;
using Application.Features.Paises.Commands.InsertarPaisesCommand;
using Application.Features.Paises.Queries.PaisesXParametros;
using Application.Features.Paises.Queries.PaisXId;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace WebAPI.Controllers.v1
{
    [ApiVersion("1.0")]
    public class PaisController : BaseApiController
    {
        [HttpGet("{id:int}", Name = "PaisXId")]
        public async Task<ActionResult> GetPaisXId(int id)
        {
            return Ok(await Mediator.Send(new PaisXIdQuery { IdPais = id }));
        }

        [HttpGet(Name = "ListarPaisesXParametros")]
        public async Task<ActionResult> GetPaisesXParametros([FromQuery] PaisParametros parametros)
        {
            return Ok(await Mediator.Send(new PaisesXParametrosQuery
            {
                NumeroDePagina = parametros.NumeroDePagina,
                RegistrosXPagina = parametros.RegistrosXPagina,
                Nombre = parametros.Nombre,
                Abreviatura = parametros.Abreviatura
            }));
        }

        [HttpPost(Name = "InsertarPais")]
        public async Task<ActionResult> PostPais(InsertarPaisCommand insertar)
        {
            return Ok(await Mediator.Send(insertar));
        }

        [HttpPut(Name = "ActualizarPais")]
        public async Task<ActionResult> PutPais(ActualizarPaisCommand actualizar)
        {
            return Ok(await Mediator.Send(actualizar));
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeletePais(int id)
        {
            return Ok(await Mediator.Send(new EliminaPaisCommand { IdPais = id }));
        }
    }
}
