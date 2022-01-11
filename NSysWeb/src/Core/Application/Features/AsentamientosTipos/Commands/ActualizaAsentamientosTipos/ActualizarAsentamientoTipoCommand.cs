using Application.Interfaces;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.AsentamientosTipos.Commands.ActualizaAsentamientosTipos
{
    public class ActualizarAsentamientoTipoCommand : IRequest<Respuesta<int>>
    {
        public int IdAsentamientoTipo { get; set; }
        public string Estatus { get; set; }
        public string Nombre { get; set; }
        public string Abreviatura { get; set; }
    }

    public class ActualizaAsentamientoTipo_Manejador : IRequestHandler<ActualizarAsentamientoTipoCommand, Respuesta<int>>
    {
        private readonly IRepositorioAsync<AsentamientoTipo> _repositorioAsync;
        private readonly IMapper _mapper;

        public ActualizaAsentamientoTipo_Manejador(IRepositorioAsync<AsentamientoTipo> repositorioAsync, IMapper mapper)
        {
            this._repositorioAsync = repositorioAsync;
            this._mapper = mapper;
        }

        public async Task<Respuesta<int>> Handle(ActualizarAsentamientoTipoCommand request, CancellationToken cancellationToken)
        {
            // consulto si existe el AsentamientoTipo
            AsentamientoTipo asentamientoTipo = await _repositorioAsync.GetByIdAsync(request.IdAsentamientoTipo);

            if (asentamientoTipo == null)
                throw new KeyNotFoundException($"No se ecuentrael registro con lo Id = { request.IdAsentamientoTipo }");

            asentamientoTipo.Estatus = request.Estatus;
            asentamientoTipo.Nombre = request.Nombre;
            asentamientoTipo.Abreviatura = request.Abreviatura;

            await _repositorioAsync.UpdateAsync(asentamientoTipo);

            return new Respuesta<int>(asentamientoTipo.IdAsentamientoTipo);
        }
    }
}
