using Application.Interfaces;
using Application.Specifications.Personas;
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
        private readonly IMapper _mapper;

        public InsertarPersona_Manejador(IRepositorioAsync<Persona> repositorioAsync, IMapper mapper)
        {
            this._repositorioAsync = repositorioAsync;
            this._mapper = mapper;
        }

        public async Task<Respuesta<int>> Handle(InsertarPersonaCommand request, CancellationToken cancellationToken)
        {
            var datosDuplicado = new ExistePersonaSpec(request.ApellidoPaterno, 
                                                       request.ApellidoPaterno,
                                                       request.Nombres);

            var existe = await _repositorioAsync.GetBySpecAsync(datosDuplicado);
               

            // Recibimos el objeto Insertar y lo mapeamos a la entidad 
            Persona persona = _mapper.Map<Persona>(request);

            // insertamos y recibimos el id de la tabla
            var respuesta = await _repositorioAsync.AddAsync(persona);

            // respondemos creando un nuevo objeto de respuesta
            return new Respuesta<int>(respuesta.IdPersona);
        }
    }
}
