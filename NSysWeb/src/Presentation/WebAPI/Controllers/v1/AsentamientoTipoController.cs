using Application.Features.AsentamientosTipos.Commands.ActualizaAsentamientosTipos;
using Application.Features.AsentamientosTipos.Commands.EliminarAsentamientosTipos;
using Application.Features.AsentamientosTipos.Commands.InsertarAsentamientosTipos;
using Application.Features.AsentamientosTipos.Queries.ListarAsentamientosTipos;
using Application.Features.AsentamientosTipos.Queries.ObtenerXIdAsentamientoTipo;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace WebAPI.Controllers.v1
{
    [ApiVersion("1.0")]
    public class AsentamientoTipoController : BaseApiController
    {
        [HttpGet(Name = "ListarAsentamientosTipos")]
        public async Task<ActionResult> GetListarAsentamientosTipos([FromQuery] AsentamientosTiposParametros asentamientosTiposParametros)
        {
            return Ok(await Mediator.Send(new ListarAsentamientosTiposQuery
            {
                NumeroPagina = asentamientosTiposParametros.NumeroDePagina,
                RegistrosXPagina = asentamientosTiposParametros.RegistrosXPagina,
                Estatus = asentamientosTiposParametros.Estatus,
                Nombre = asentamientosTiposParametros.Nombre,
                Abeviatura = asentamientosTiposParametros.Abreviatura
            }));
        }

        [HttpGet("{id:int}", Name = "ObtenerXIdAsentamientoTipo")]
        public async Task<ActionResult> GetObtenerXIdAsentemiento(int id)
        {
            return Ok(await Mediator.Send(new ObtenerXIdAsentamientoTipoQuery { IdAsentamientoTipo = id }));
        }

        [HttpPost(Name = "InsertarAsentamientoTipo")]
        public async Task<ActionResult> PostAsentamientoTipo(InsertarAsentamientoTipoCommand asentamientoTipo)
        {
            return Ok(await Mediator.Send(asentamientoTipo));
        }

        [HttpPut(Name = "ActualizarAsentamientoTipo")]
        public async Task<ActionResult> UpdateAsentamientoTipo(ActualizarAsentamientoTipoCommand asentamiento)
        {
            return Ok(await Mediator.Send(asentamiento));
        }

        [HttpDelete("{id:int}", Name = "EliminarAsentamientoTipo")]
        public async Task<ActionResult> DeleteAsentamientoTipo(int id)
        {
            return Ok(await Mediator.Send(new EliminarAsentamientoTipoCommand { IdAsentamientoTipo = id }));
        }
    }
}
