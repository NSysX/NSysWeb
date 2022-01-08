using Application.Interfaces;
using Application.Wrappers;
using Domain.Entities;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Asentamientos.Commands.EliminarAsentamientosCommand
{
    public class EliminarAsentamientoCommand : IRequest<Respuesta<int>>
    {
        public int IdAsentamiento { get; set; }
    }

    public class EliminarAsentamiento_Manejador : IRequestHandler<EliminarAsentamientoCommand, Respuesta<int>>
    {
        private readonly IRepositorioAsync<Asentamiento> _repositorioAsync;

        public EliminarAsentamiento_Manejador(IRepositorioAsync<Asentamiento> repositorioAsync)
        {
            this._repositorioAsync = repositorioAsync;
        }

        public async Task<Respuesta<int>> Handle(EliminarAsentamientoCommand request, CancellationToken cancellationToken)
        {
            Asentamiento asentamiento = await _repositorioAsync.GetByIdAsync(request.IdAsentamiento, cancellationToken);

            if (asentamiento == null)
                throw new KeyNotFoundException($"No se encontro el registro con el Id ={ request.IdAsentamiento }");

            await _repositorioAsync.DeleteAsync(asentamiento, cancellationToken);

            return new Respuesta<int>(asentamiento.IdAsentamiento);
        }
    }
}
