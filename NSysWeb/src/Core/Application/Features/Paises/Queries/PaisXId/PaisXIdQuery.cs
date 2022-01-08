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

namespace Application.Features.Paises.Queries.PaisXId
{
    public class PaisXIdQuery : IRequest<Respuesta<PaisDTO>>
    {
        public int IdPais { get; set; }
    }

    public class PaisXId_Manejador : IRequestHandler<PaisXIdQuery, Respuesta<PaisDTO>>
    {
        private readonly IRepositorioAsync<Pais> _repositorioAsync;
        private readonly IMapper _mapper;

        public PaisXId_Manejador(IRepositorioAsync<Pais> repositorioAsync, IMapper mapper)
        {
            this._repositorioAsync = repositorioAsync;
            this._mapper = mapper;
        }

        public async Task<Respuesta<PaisDTO>> Handle(PaisXIdQuery request, CancellationToken cancellationToken)
        {
            Pais pais = await _repositorioAsync.GetByIdAsync(request.IdPais, cancellationToken);
            if (pais == null)
                throw new KeyNotFoundException($"No Existe el Pais con Id = { request.IdPais }");

            PaisDTO paisDTO = _mapper.Map<PaisDTO>(pais);

            return new Respuesta<PaisDTO>(paisDTO);
        }
    }
}
