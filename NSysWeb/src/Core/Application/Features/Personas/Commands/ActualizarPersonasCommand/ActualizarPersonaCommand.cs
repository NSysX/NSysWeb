using Application.Interfaces;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Personas.Commands.ActualizarPersonasCommand
{
    public class ActualizarPersonaCommand : IRequest<Respuesta<int>>
    {
        public int IdPersona { get; set; }
        public int IdNacionalidad { get; set; }
        public int IdEstadoCivil { get; set; }
        public string Estatus { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public string Nombres { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Sexo { get; set; }
        public string Foto { get; set; }
        public string Notas { get; set; }
    }

    public class ActualizarPersona_Manejador : IRequestHandler<ActualizarPersonaCommand, Respuesta<int>>
    {
        private readonly IRepositorioAsync<Persona> _repositoryAsync;
        private readonly IMapper _mapper;

        public ActualizarPersona_Manejador(IRepositorioAsync<Persona> repositoryAsync, IMapper mapper)
        {
            this._repositoryAsync = repositoryAsync;
            this._mapper = mapper;
        }

        public async Task<Respuesta<int>> Handle(ActualizarPersonaCommand request, CancellationToken cancellationToken)
        {
            Persona persona = await _repositoryAsync.GetByIdAsync(request.IdPersona);

            if (persona == null)
                throw new KeyNotFoundException($"No se encontr el Registro con el Id = { request.IdPersona }");

            persona.IdNacionalidad = request.IdNacionalidad;
            persona.IdEstadoCivil = request.IdEstadoCivil;
            persona.Estatus = request.Estatus;
            persona.ApellidoPaterno = request.ApellidoPaterno;
            persona.ApellidoMaterno = request.ApellidoMaterno;
            persona.Nombres = request.Nombres;
            persona.FechaNacimiento = request.FechaNacimiento;
            persona.Sexo = request.Sexo;
            persona.Foto = request.Foto;
            persona.Notas = request.Notas;

            await _repositoryAsync.UpdateAsync(persona, cancellationToken);

            return new Respuesta<int>(persona.IdPersona);
        }
    }
}
