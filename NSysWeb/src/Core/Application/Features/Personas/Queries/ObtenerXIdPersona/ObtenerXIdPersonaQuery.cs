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

namespace Application.Features.Personas.Queries.ObtenerXIdPersona
{
    public class ObtenerXIdPersonaQuery : IRequest<Respuesta<PersonaDTO>>
    {
        public int IdPersona { get; set; }
    }

    public class ObtenerXIdPersona_Manejador : IRequestHandler<ObtenerXIdPersonaQuery, Respuesta<PersonaDTO>>
    {
        private readonly IRepositorioAsync<Persona> _repositorioAsync;
        private readonly IMapper _mapper;

        public ObtenerXIdPersona_Manejador(IRepositorioAsync<Persona> repositorioAsync, IMapper mapper)
        {
            this._repositorioAsync = repositorioAsync;
            this._mapper = mapper;
        }

        public async Task<Respuesta<PersonaDTO>> Handle(ObtenerXIdPersonaQuery request, CancellationToken cancellationToken)
        {
            Persona persona = await _repositorioAsync.GetByIdAsync(request.IdPersona, cancellationToken);

            if (persona == null)
                throw new KeyNotFoundException($"No se encontro el Registro con el Id = { request.IdPersona }");

            PersonaDTO personaDTO = _mapper.Map<PersonaDTO>(persona);

            return new Respuesta<PersonaDTO>(personaDTO);
        }
    }
}
