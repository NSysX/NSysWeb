using Application.Features.Municipios.Commands.ActualizarMunicipiosCommand;
using Application.Features.Municipios.Commands.EliminarMunicipiosCommand;
using Application.Features.Municipios.Commands.InsertarMunicipiosCommand;
using Application.Features.Municipios.Queries.MunicipiosXParametros;
using Application.Features.Municipios.Queries.MunicipioXId;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace WebAPI.Controllers.v1
{
    [ApiVersion("1.0")]
    public class MunicipioController : BaseApiController
    {
        [HttpGet("{id:int}", Name = "MunicipioXId")]
        public async Task<ActionResult> GetMunicipioXId(int id)
        {
            return Ok(await Mediator.Send(new MunicipioXIdQuery { IdMunicipio = id }));
        }

        [HttpGet(Name = "MunicipiosXParametros")]
        public async Task<ActionResult> GetMunicipio([FromQuery] MunicipioParametros parametros)
        {
            return Ok(await Mediator.Send(new MunicipiosXParametrosQuery
            {
                NumeroDePagina = parametros.NumeroDePagina,
                RegistrosXPagina = parametros.RegistrosXPagina,
                Nombre = parametros.Nombre,
                Clave = parametros.Clave
            }));
        }

        [HttpPost(Name = "InsertaMunicipio")]
        public async Task<ActionResult> PostMunicipio(InsertarMunicipioCommand insertar)
        {
            return Ok(await Mediator.Send(insertar));
        }

        [HttpPut(Name = "ActualizarMunicipio")]
        public async Task<ActionResult> PutMunicipio(ActualizarMunicipioCommand actualizar)
        {
            return Ok(await Mediator.Send(actualizar));
        }

        [HttpDelete("{id:int}", Name = "EliminarMunicipio")]
        public async Task<ActionResult> DelMunicipio(int id)
        {
            return Ok(await Mediator.Send(new EliminarMunicipioCommand { IdMunicipio = id }));
        }
    }
}
