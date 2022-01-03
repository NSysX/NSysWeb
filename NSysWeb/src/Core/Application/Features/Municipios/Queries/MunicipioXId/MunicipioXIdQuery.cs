using Application.DTOs;
using Application.Interfaces;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Municipios.Queries.MunicipioXId
{
    public class MunicipioXIdQuery : IRequest<Respuesta<MunicipioDTO>>
    {
        public int IdMunicipio { get; set; }
    }

    public class MunicipioXId_Manejador : IRequestHandler<MunicipioXIdQuery, Respuesta<MunicipioDTO>>
    {
        private readonly IRepositorioAsync<Municipio> _repositorioAsync;
        private readonly IMapper _mapper;

        public MunicipioXId_Manejador(IRepositorioAsync<Municipio> repositorioAsync, IMapper mapper)
        {
            this._repositorioAsync = repositorioAsync;
            this._mapper = mapper;
        }

        public async Task<Respuesta<MunicipioDTO>> Handle(MunicipioXIdQuery request, CancellationToken cancellationToken)
        {
            Municipio municipio = await _repositorioAsync.GetByIdAsync(request.IdMunicipio, cancellationToken);

            if (municipio == null)
                throw new KeyNotFoundException($"No se Encontro el registro con el Id = { request.IdMunicipio }");

            MunicipioDTO municipioDTO = _mapper.Map<MunicipioDTO>(municipio);

            return new Respuesta<MunicipioDTO>(municipioDTO);
        }
    }
}
