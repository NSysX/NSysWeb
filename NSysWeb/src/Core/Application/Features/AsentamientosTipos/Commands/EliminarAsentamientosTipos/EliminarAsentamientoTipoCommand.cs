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

namespace Application.Features.AsentamientosTipos.Commands.EliminarAsentamientosTipos
{
    public class EliminarAsentamientoTipoCommand : IRequest<Respuesta<int>>
    {
        public int IdAsentamientoTipo { get; set; }
    }

    public class EliminarAsentamientoTipo_Manejador : IRequestHandler<EliminarAsentamientoTipoCommand, Respuesta<int>>
    {
        private readonly IRepositorioAsync<AsentamientoTipo> _repositorioAsync;

        public EliminarAsentamientoTipo_Manejador(IRepositorioAsync<AsentamientoTipo> repositorioAsync)
        {
            this._repositorioAsync = repositorioAsync;
        }

        public async Task<Respuesta<int>> Handle(EliminarAsentamientoTipoCommand request, CancellationToken cancellationToken)
        {
            // verificamos si existe
            AsentamientoTipo asentamientoTipo = await _repositorioAsync.GetByIdAsync(request.IdAsentamientoTipo, cancellationToken);

            if (asentamientoTipo == null)
                throw new KeyNotFoundException($"No se encuentra el Registro con el Id = { request.IdAsentamientoTipo }");

            await _repositorioAsync.DeleteAsync(asentamientoTipo);

            return new Respuesta<int>(asentamientoTipo.IdAsentamientoTipo);
        }
    }
}
