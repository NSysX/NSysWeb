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

namespace Application.Features.Nacionalidades.Queries.ObtenerXIdNacionalidad
{
    public class ObtenerXIdNacionalidadQuery : IRequest<Respuesta<NacionalidadDTO>>
    {
        public int IdNacionalidad { get; set; }
    }

    public class ObtenerXIdNacionalidad_Manejador : IRequestHandler<ObtenerXIdNacionalidadQuery, Respuesta<NacionalidadDTO>>
    {
        private readonly IRepositorioAsync<Nacionalidad> _repositorioAsync;
        private readonly IMapper _mapper;

        public ObtenerXIdNacionalidad_Manejador(IRepositorioAsync<Nacionalidad> repositorioAsync,
                                                IMapper mapper)
        {
            this._repositorioAsync = repositorioAsync;
            this._mapper = mapper;
        }

        public async Task<Respuesta<NacionalidadDTO>> Handle(ObtenerXIdNacionalidadQuery request,
                                                             CancellationToken cancellationToken)
        {
            Nacionalidad nacionalidad = await _repositorioAsync.GetByIdAsync(request.IdNacionalidad);

            if (nacionalidad == null)
                throw new KeyNotFoundException($"No se Encontro el Registro con el Id = { request.IdNacionalidad }");

            NacionalidadDTO nacionalidadDTO = _mapper.Map<NacionalidadDTO>(nacionalidad);

            return new Respuesta<NacionalidadDTO>(nacionalidadDTO);
        }
    }
}
