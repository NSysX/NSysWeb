using Application.Features.Nacionalidades.Commands;
using Application.Features.Nacionalidades.Commands.ActualizarNacionalidadesCommand;
using Application.Features.Nacionalidades.Commands.EliminarNacionalidadesCommand;
using Application.Features.Nacionalidades.Queries;
using Application.Features.Nacionalidades.Queries.ObtenerXIdNacionalidad;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace WebAPI.Controllers.v1
{
    [ApiVersion("1.0")]
    public class NacionalidadController : BaseApiController
    {
        [HttpGet("{id:int}", Name = "ObtenerXidNacionalidad")]
        public async Task<ActionResult> ObtenerXIdNacionalidad(int id)
        {
            return Ok(await Mediator.Send(new ObtenerXIdNacionalidadQuery { IdNacionalidad = id }));
        }

        [HttpGet(Name = "ListarXParametroNacionalidad")]
        public async Task<ActionResult> GetNacionalidadXParametro([FromQuery] NacionalidadParametros parametros)
        {
            return Ok(await Mediator.Send(new ListarNacionalidadesQuery 
            {   Descripcion = parametros.Descripcion, 
                Estatus = parametros.Estatus, 
                NumeroDePagina = parametros.NumeroDePagina,
                RegistrosXPagina = parametros.RegistrosXPagina 
            }));
        }

        [HttpPost(Name = "InsertaNacionalidad")]
        public async Task<ActionResult> PostNacionalidad(InsertaNacionalidadCommand nacionalidad)
        {
            return Ok(await Mediator.Send(nacionalidad));
        }

        [HttpPut(Name = "ActualizaNacionalidad")]
        public async Task<ActionResult> UpdateNacionalidad(ActualizaNacionalidadCommand actualiza)
        {
            return Ok(await Mediator.Send(actualiza));
        }

        [HttpDelete("{id:int}",Name = "EliminaNacionalidad_Fisico")]
        public async Task<ActionResult> DeleteNacionalidad(int id)
        {
            // creamos el objeto y le asignamos el id a la propiedad
            return Ok(await Mediator.Send(new EliminarNacionalidadCommand { IdNacionalidad = id}));
        }  
    }
}
