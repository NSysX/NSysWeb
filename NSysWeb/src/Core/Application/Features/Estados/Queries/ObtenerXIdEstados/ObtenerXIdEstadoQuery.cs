using Application.DTOs;
using Application.Interfaces;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Estados.Queries.ObtenerXIdEstados
{
    public class ObtenerXIdEstadoQuery : IRequest<Respuesta<EstadoDTO>>
    {
        public int IdEstado { get; set; }
    }

    public class ObtenerXIdEstado_Manejador : IRequestHandler<ObtenerXIdEstadoQuery, Respuesta<EstadoDTO>>
    {
        private readonly IRepositorioAsync<Estado> _repositorioAsync;
        private readonly IMapper _mapper;

        public ObtenerXIdEstado_Manejador(IRepositorioAsync<Estado> repositorioAsync, IMapper mapper)
        {
            this._repositorioAsync = repositorioAsync;
            this._mapper = mapper;
        }

        public async Task<Respuesta<EstadoDTO>> Handle(ObtenerXIdEstadoQuery request, CancellationToken cancellationToken)
        {
            Estado estado = await _repositorioAsync.GetByIdAsync(request.IdEstado);

            if (estado == null)
                throw new KeyNotFoundException($"No se encontro el registro con el Id = { request.IdEstado }");

            EstadoDTO estadoDto = _mapper.Map<EstadoDTO>(estado);

            return new Respuesta<EstadoDTO>(estadoDto);
        }
    }
}
