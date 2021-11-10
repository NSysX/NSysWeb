using Application.Features.EstadosCiviles.Commands.InsertarEstadosCivilesCommand;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers.v1
{
    [ApiVersion("1.0")]
    public class EstadoCivilController : BaseApiController
    {
        [HttpPost]
        public async Task<IActionResult> Post(InsertarEstadoCivilCommand insertarEstadoCivilCommand)
        {
            return Ok(await Mediator.Send(insertarEstadoCivilCommand));
        }
    }
}
