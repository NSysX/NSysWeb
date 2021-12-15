using Application.DTOs;
using Application.Interfaces;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.AsentamientosTipos.Queries.ObtenerXIdAsentamientoTipo
{
    public class ObtenerXIdAsentamientoTipoQuery : IRequest<Respuesta<AsentamientoTipoDTO>>
    {
        public int IdAsentamientoTipo { get; set; }
    }

    public class ObtenerXIdAsentamientoTipo_Manejador : IRequestHandler<ObtenerXIdAsentamientoTipoQuery, Respuesta<AsentamientoTipoDTO>>
    {
        private readonly IRepositorioAsync<AsentamientoTipo> _repositoryAsync;
        private readonly IMapper _mapper;

        public ObtenerXIdAsentamientoTipo_Manejador(IRepositorioAsync<AsentamientoTipo> repositoryAsync, IMapper mapper)
        {
            this._repositoryAsync = repositoryAsync;
            this._mapper = mapper;
        }

        public async Task<Respuesta<AsentamientoTipoDTO>> Handle(ObtenerXIdAsentamientoTipoQuery request, CancellationToken cancellationToken)
        {
            AsentamientoTipo asentamientoTipo = await _repositoryAsync.GetByIdAsync(request.IdAsentamientoTipo);

            if (asentamientoTipo == null)
                throw new KeyNotFoundException($"No se encontro el registro con el Id = { request.IdAsentamientoTipo }");

            AsentamientoTipoDTO asentamientoTipoDTO = _mapper.Map<AsentamientoTipoDTO>(asentamientoTipo);

            return new Respuesta<AsentamientoTipoDTO>(asentamientoTipoDTO);
        }
    }
}
