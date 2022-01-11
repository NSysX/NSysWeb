using Application.DTOs;
using Application.Interfaces;
using Application.Specifications.Asentamientos;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Asentamientos.Queries.AsentamientoXId
{
    public class AsentamientoXIdQuery : IRequest<Respuesta<AsentamientoDTO>>
    {
        public int IdAsentamiento { get; set; }
    }

    public class AsentamientoXId_Manejador : IRequestHandler<AsentamientoXIdQuery, Respuesta<AsentamientoDTO>>
    {
        private readonly IRepositorioAsync<Asentamiento> _repositorioAsync;
        private readonly IMapper _mapper;

        public AsentamientoXId_Manejador(IRepositorioAsync<Asentamiento> repositorioAsync, IMapper mapper)
        {
            this._repositorioAsync = repositorioAsync;
            this._mapper = mapper;
        }

        public async Task<Respuesta<AsentamientoDTO>> Handle(AsentamientoXIdQuery request, CancellationToken cancellationToken)
        {
            var asentamientoXIdSpec = new AsentamientoXIdSpec(request.IdAsentamiento);
            Asentamiento asentamiento = await _repositorioAsync.GetBySpecAsync(asentamientoXIdSpec, cancellationToken);

            if (asentamiento == null)
                throw new KeyNotFoundException($"No se encontro el Registro con el Id = { request.IdAsentamiento }");

            AsentamientoDTO asentamientoDTO = _mapper.Map<AsentamientoDTO>(asentamiento);

            return new Respuesta<AsentamientoDTO>(asentamientoDTO);
        }
    }
}
