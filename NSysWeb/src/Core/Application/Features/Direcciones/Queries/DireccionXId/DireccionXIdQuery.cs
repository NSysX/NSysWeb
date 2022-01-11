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

namespace Application.Features.Direcciones.Queries.DireccionXId
{
    public class DireccionXIdQuery : IRequest<Respuesta<DireccionDTO>>
    {
        public int IdDireccion { get; set; }
    }

    public class DireccionXId_Manejador : IRequestHandler<DireccionXIdQuery, Respuesta<DireccionDTO>>
    {
        private readonly IRepositorioAsync<Direccion> _repositorioAsyncDir;
        private readonly IMapper _mapper;

        public DireccionXId_Manejador(IRepositorioAsync<Direccion> repositorioAsyncDir, IMapper mapper)
        {
            this._repositorioAsyncDir = repositorioAsyncDir;
            this._mapper = mapper;
        }

        public async Task<Respuesta<DireccionDTO>> Handle(DireccionXIdQuery request, CancellationToken cancellationToken)
        {
            Direccion direccion = await _repositorioAsyncDir.GetByIdAsync(request.IdDireccion, cancellationToken);
            if (direccion == null)
                throw new KeyNotFoundException($"No Existe Direccion con Id = { request.IdDireccion }");

            DireccionDTO direccionDTO = _mapper.Map<DireccionDTO>(direccion);

            return new Respuesta<DireccionDTO>(direccionDTO);
        }
    }
}
