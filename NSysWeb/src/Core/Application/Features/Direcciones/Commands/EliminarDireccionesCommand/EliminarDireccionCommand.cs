using Application.Interfaces;
using Application.Wrappers;
using Domain.Entities;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Direcciones.Commands.EliminarDireccionesCommand
{
    public class EliminarDireccionCommand : IRequest<Respuesta<int>>
    {
        public int IdDireccion { get; set; }
    }

    public class EliminarDireccion_Manejador : IRequestHandler<EliminarDireccionCommand, Respuesta<int>>
    {
        private readonly IRepositorioAsync<Direccion> _repositorioAsyncDireccion;

        public EliminarDireccion_Manejador(IRepositorioAsync<Direccion> repositorioAsyncDireccion)
        {
            this._repositorioAsyncDireccion = repositorioAsyncDireccion;
        }

        public async Task<Respuesta<int>> Handle(EliminarDireccionCommand request, CancellationToken cancellationToken)
        {
            // verifico que exista el registro
            Direccion direccion = await _repositorioAsyncDireccion.GetByIdAsync(request.IdDireccion, cancellationToken);
            if (direccion == null)
                throw new KeyNotFoundException($"No Existe Direcccion Con Id = { request.IdDireccion }");

            await _repositorioAsyncDireccion.DeleteAsync(direccion, cancellationToken);

            return new Respuesta<int>(direccion.IdDireccion);
        }
    }
}
