using Application.Features.Documentos.Commands.ActualizarDocumentosCommand;
using Application.Features.Documentos.Commands.EliminarDocumentosCommand;
using Application.Features.Documentos.Commands.InsertarDocumentosCommand;
using Application.Features.Documentos.Queries.ListarDocumentos;
using Application.Features.Documentos.Queries.ObtenerXIdDocumento;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace WebAPI.Controllers.v1
{
    [ApiVersion("1.0")]
    public class DocumentoController : BaseApiController
    {
        [HttpGet(Name = "ListarDocumentos")]
        public async Task<ActionResult> GetListarDocumentos([FromQuery] DocumentosParametros documentos)
        {
            return Ok(await Mediator.Send(new ListarDocumentosQuery
            {
                NumeroDePagina = documentos.NumeroDePagina,
                RegistrosXPagina = documentos.RegistrosXPagina,
                Estatus = documentos.Estatus,
                CodigoUnico = documentos.CodigoUnico
            }));
        }

        [HttpGet("{id:int}", Name = "ObtenerXIdDocumento")]
        public async Task<ActionResult> GetObtenerXIdDocumento(int id)
        {
            return Ok(await Mediator.Send(new ObtenerXIdDocumentoQuery { IdDocumento = id}));
        }

        [HttpPost(Name = "InsertarDocumento")]
        public async Task<ActionResult> PostDocumento(InsertarDocumentoCommand insertarDocumentoCommand)
        {
            return Ok(await Mediator.Send(insertarDocumentoCommand));
        }

        [HttpPut(Name = "ActualizarDocumento")]
        public async Task<ActionResult> PutDocumento(ActualizarDocumentoCommand actualizarDocumentoCommand)
        {
            return Ok(await Mediator.Send(actualizarDocumentoCommand));
        }

        [HttpDelete("{id:int}", Name = "EliminarDocumento_Fisico")]
        public async Task<ActionResult> DeleteDocumento_Fisico(int id)
        {
            return Ok(await Mediator.Send(new EliminarDocumentoCommand { IdDocumento = id }));
        }
    }
}
