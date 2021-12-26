using Application.Features.DocumentosTipos.Queries.ObtenerXIdDocumentoTipo;
using Application.Features.DocumentosTipos.Commands.ActualizarDocumentosTiposCommand;
using Application.Features.DocumentosTipos.Commands.EliminarDocumentosTiposCommand;
using Application.Features.DocumentosTipos.Commands.InsertarDocumentosTiposCommand;
using Application.Features.DocumentosTipos.Queries.ListarDocumentosTipos;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace WebAPI.Controllers.v1
{
    [ApiVersion("1.0")]
    public class DocumentoTipoController : BaseApiController
    {
        [HttpGet("{Id:int}", Name = "ObtenerXIdDocumentoTipo")]
        public async Task<ActionResult> GetDocumentosTiposXId(int Id)
        {
            return Ok(await Mediator.Send(new ObtenerXIdDocumentoTipoQuery { IdDocumentoTipo = Id}));
        }

        [HttpGet(Name = "ListarXParametrosDocumentosTipos")]
        public async Task<ActionResult> GetDocumentosTiposXParametros([FromQuery] DocumentosTiposParametros documentosTiposParametros)
        {
            return Ok(await Mediator.Send(new ListarDocumentosTiposQuery
            {
                NumeroDePagina = documentosTiposParametros.NumeroDePagina,
                RegistrosXPagina = documentosTiposParametros.RegistrosXPagina,
                Nombre = documentosTiposParametros.Nombre,
                Abreviatura = documentosTiposParametros.Abreviatura,
                Estatus = documentosTiposParametros.Estatus
            }));    
        }

        [HttpPost(Name = "InsertarDocumentoTipo")]
        public async Task<ActionResult> PostDocumentosTipos(InsertarDocumentoTipoCommand insertaDocumentoTipoCommand)
        {
            return Ok(await Mediator.Send(insertaDocumentoTipoCommand));
        }

        [HttpPut(Name = "ActualizarDocumentoTipo")]
        public async Task<ActionResult> PutDocumentosTipos(ActualizarDocumentoTipoCommand actualizarDocumentoTipoCommand)
        {
            return Ok(await Mediator.Send(actualizarDocumentoTipoCommand));
        }

        [HttpDelete("{id:int}", Name = "EliminarDocumentoTipo_Fisico")]
        public async Task<ActionResult> DeleteDocumentosTipos(int id)
        {
            return Ok(await Mediator.Send(new EliminarDocumentoTipoCommand { IdDocumentoTipo = id }));
        }
    }
}
