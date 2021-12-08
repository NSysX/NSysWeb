using Application.Features.Documentos.Commands.ActualizarDocumentosCommand;
using Application.Features.Documentos.Commands.EliminarDocumentosCommand;
using Application.Features.Documentos.Commands.InsertarDocumentosCommand;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace WebAPI.Controllers.v1
{
    [ApiVersion("1.0")]
    public class DocumentoController : BaseApiController
    {


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
