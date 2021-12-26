using Application.Features.CorreosElectronicos.Commands.ActualizarCorreosElectronicosCommand;
using Application.Features.CorreosElectronicos.Commands.EliminarCorreosElectronicosCommand;
using Application.Features.CorreosElectronicos.Commands.InsertarCorreosElectronicosCommand;
using Application.Features.CorreosElectronicos.Queries.ListarCorreosElectronicos;
using Application.Features.CorreosElectronicos.Queries.ObtenerXIdCorreoElectronico;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace WebAPI.Controllers.v1
{
    [ApiVersion("1.0")]
    public class CorreoElectronicoController : BaseApiController
    {
        [HttpGet(Name = "ListarXParametrosCorreosElectronicos")]
        public async Task<ActionResult> GetXParametrosCorreosElectronicos([FromQuery] CorreosElectronicosParametros correos)
        {
            return Ok(await Mediator.Send(new ListarCorreosElectronicosQuery
            {
                NumeroDePagina = correos.NumeroDePagina,
                RegistrosXPagina = correos.RegistrosXPagina,
                Estatus = correos.Estatus,
                Correo = correos.Correo
            }));
        }

        [HttpGet("{id:int}", Name = "ObtenerXIdCorreoElectronico")]
        public async Task<ActionResult> GetByIdCorreoElectronico(int id)
        {
            return Ok(await Mediator.Send(new ObtenerXIdCorreoElectronicoQuery { IdCorreoElectronico = id }));
        }

        [HttpPost(Name = "InsertarCorreoElectronico")]
        public async Task<ActionResult> PostCorreoElectronico(InsertarCorreoElectronicoCommand insertar)
        {
            return Ok(await Mediator.Send(insertar));
        }

        [HttpPut(Name = "ActualizarCorreoElectronico")]
        public async Task<ActionResult> PutCorreoElectronico(ActualizarCorreoElectronicoCommand actualizar)
        {
            return Ok(await Mediator.Send(actualizar));
        }

        [HttpDelete("{id:int}", Name = "EliminarCorreoElectronico")]
        public async Task<ActionResult> DeleteCorreoElectronico(int id)
        {
            return Ok(await Mediator.Send(new EliminarCorreoElectronicoCommand { IdCorreoElectronico = id }));
        }
    }
}
