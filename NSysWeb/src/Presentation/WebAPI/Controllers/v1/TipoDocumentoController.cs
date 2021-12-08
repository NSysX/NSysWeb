using Application.Features.TiposDocumentos.Commands.ActualizarTiposDocumentosCommand;
using Application.Features.TiposDocumentos.Commands.EliminarTiposDocumentosCommand;
using Application.Features.TiposDocumentos.Commands.InsertarTiposDocumentosCommand;
using Application.Features.TiposDocumentos.Queries.ListarTiposDocumentos;
using Application.Features.TiposDocumentos.Queries.ObtenerXIdTipoDocumento;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace WebAPI.Controllers.v1
{
    [ApiVersion("1.0")]
    public class TipoDocumentoController : BaseApiController
    {
        [HttpGet("{Id:int}", Name = "ObtenerXIdTipoDocumento")]
        public async Task<ActionResult> GetTiposDocumentosXId(int Id)
        {
            return Ok(await Mediator.Send(new ObtenerXIdTipoDocumentoQuery { IdTipoDocumento = Id}));
        }

        [HttpGet(Name = "ListarXParametrosTiposDocumentos")]
        public async Task<ActionResult> GetTiposDocumentosXParametros([FromQuery] TiposDocumentosParametros tiposDocumentosParametros)
        {
            return Ok(await Mediator.Send(new ListarTiposDocumentosQuery
            {
                NumeroPagina = tiposDocumentosParametros.NumeroDePagina,
                RegistrosXPagina = tiposDocumentosParametros.RegistrosXPagina,
                Nombre = tiposDocumentosParametros.Nombre,
                Abreviacion = tiposDocumentosParametros.Abreviacion,
                Estatus = tiposDocumentosParametros.Estatus
            }));
            
        }

        [HttpPost(Name = "InsertarTipoDocumento")]
        public async Task<ActionResult> PostTiposDocumentos(InsertarTipoDocumentoCommand insertaTipoDocumentoCommand)
        {
            return Ok(await Mediator.Send(insertaTipoDocumentoCommand));
        }

        [HttpPut(Name = "ActualizarTipoDocumento")]
        public async Task<ActionResult> PutTiposDocumentos(ActualizarTipoDocumentoCommand actualizarTipoDocumentoCommand)
        {
            return Ok(await Mediator.Send(actualizarTipoDocumentoCommand));
        }

        [HttpDelete("{id:int}", Name = "EliminarTipoDocumento_Fisico")]
        public async Task<ActionResult> DeleteTiposDocumentos(int id)
        {
            return Ok(await Mediator.Send(new EliminarTipoDocumentoCommand { IdTipoDocumento = id }));
        }
    }
}
