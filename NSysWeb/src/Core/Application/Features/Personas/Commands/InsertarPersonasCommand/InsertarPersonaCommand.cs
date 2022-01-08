using Application.Interfaces;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Personas.Commands.InsertarPersonasCommand
{
    public class InsertarPersonaCommand : IRequest<Respuesta<int>>
    {
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

    public class InsertarPersona_Manejador : IRequestHandler<InsertarPersonaCommand, Respuesta<int>>
    {
        private readonly IRepositorioAsync<Persona> _repositorioAsync;
        private readonly IRepositorioAsync<Nacionalidad> _repositorioNacionalidad;
        private readonly IRepositorioAsync<EstadoCivil> _repositorioEstadoCivil;
        private readonly IMapper _mapper;

        public InsertarPersona_Manejador(IRepositorioAsync<Persona> repositorioAsync, 
                                         IRepositorioAsync<Nacionalidad> repositorioNacionalidad,
                                         IRepositorioAsync<EstadoCivil> repositorioEstadoCivil,
                                         IMapper mapper)
        {
            this._repositorioAsync = repositorioAsync;
            this._repositorioNacionalidad = repositorioNacionalidad;
            this._repositorioEstadoCivil = repositorioEstadoCivil;
            this._mapper = mapper;
        }

        public async Task<Respuesta<int>> Handle(InsertarPersonaCommand request, CancellationToken cancellationToken)
        {
            // verifico que exista la Nacionalidad            
            var nacionalidadExiste = await _repositorioNacionalidad.GetByIdAsync(request.IdNacionalidad, cancellationToken);
            if (nacionalidadExiste == null)
                throw new KeyNotFoundException($"No Existe la Nacionalidad con el Id = { request.IdNacionalidad }");

            // verifico que exista el EstadoCivil
            var estadoCivilExiste = await _repositorioEstadoCivil.GetByIdAsync(request.IdEstadoCivil, cancellationToken);
            if (estadoCivilExiste == null)
                throw new KeyNotFoundException($"No Existe el Estado Civil con el Id = { request.IdEstadoCivil }");

            // Recibimos el objeto Insertar y lo mapeamos a la entidad 
            Persona persona = _mapper.Map<Persona>(request);

            // insertamos y recibimos el id de la tabla
            var respuesta = await _repositorioAsync.AddAsync(persona, cancellationToken);

            // respondemos creando un nuevo objeto de respuesta
            return new Respuesta<int>(respuesta.IdPersona);
        }
    }
}
