using Application.Interfaces;
using Application.Wrappers;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.EstadosCiviles.Commands.EliminarEstadosCivilesCommand
{
    public class EliminarEstadoCivilCommand : IRequest<Respuesta<int>>
    {
        public int IdEstadoCivil { get; set; }
    }

    public class EliminarEstadoCivilCommand_Manejador : IRequestHandler<EliminarEstadoCivilCommand, Respuesta<int>>
    {
        private readonly IRepositorioAsync<EstadoCivil> _respositorioAsync_EstadoCivil;

        public EliminarEstadoCivilCommand_Manejador(IRepositorioAsync<EstadoCivil> respositorioAsync_EstadoCivil)
        {
            this._respositorioAsync_EstadoCivil = respositorioAsync_EstadoCivil;
        }

        public async Task<Respuesta<int>> Handle(EliminarEstadoCivilCommand estadoCivilCommand, CancellationToken cancellationToken)
        {
            var existe_EstadoCivil = await _respositorioAsync_EstadoCivil.GetByIdAsync(estadoCivilCommand.IdEstadoCivil, cancellationToken);

            if (existe_EstadoCivil == null)
                throw new KeyNotFoundException($"Registro no Encontrado con el Id = { estadoCivilCommand.IdEstadoCivil }");

            await _respositorioAsync_EstadoCivil.DeleteAsync(existe_EstadoCivil);
            return new Respuesta<int>(existe_EstadoCivil.IdEstadoCivil);

        }
    }
}
