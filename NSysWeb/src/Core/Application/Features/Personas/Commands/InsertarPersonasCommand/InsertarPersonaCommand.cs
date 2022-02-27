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
        private readonly IRepositorioAsync<Persona> _repoPersonaAsync;
        private readonly IRepositorioAsync<Nacionalidad> _repoNacionalidadAsync;
        private readonly IRepositorioAsync<EstadoCivil> _repoEstadoCivilAsync;
        private readonly IMapper _mapper;

        public InsertarPersona_Manejador(IRepositorioAsync<Persona> repoPersona,
                                         IRepositorioAsync<Nacionalidad> repoNacionalidad,
                                         IRepositorioAsync<EstadoCivil> repoEstadoCivil,
                                         IMapper mapper)
        {
            this._repoPersonaAsync = repoPersona;
            this._repoNacionalidadAsync = repoNacionalidad;
            this._repoEstadoCivilAsync = repoEstadoCivil;
            this._mapper = mapper;
        }

        public async Task<Respuesta<int>> Handle(InsertarPersonaCommand request, CancellationToken cancellationToken)
        {
            // verifico que exista la Nacionalidad            
            var nacionalidadExiste = await _repoNacionalidadAsync.GetByIdAsync(request.IdNacionalidad, cancellationToken);
            if (nacionalidadExiste == null)
                throw new KeyNotFoundException($"No Existe la Nacionalidad con el Id = { request.IdNacionalidad }");

            // verifico que exista el EstadoCivil
            var estadoCivilExiste = await _repoEstadoCivilAsync.GetByIdAsync(request.IdEstadoCivil, cancellationToken);
            if (estadoCivilExiste == null)
                throw new KeyNotFoundException($"No Existe el Estado Civil con el Id = { request.IdEstadoCivil }");

            // Recibimos el objeto Insertar y lo mapeamos a la entidad 
            Persona persona = _mapper.Map<Persona>(request);

            // insertamos y recibimos el id de la tabla
            var respuesta = await _repoPersonaAsync.AddAsync(persona, cancellationToken);

            // respondemos creando un nuevo objeto de respuesta
            return new Respuesta<int>(respuesta.IdPersona);
        }
    }
}

//    try
//    {
//        //CQRS
//        using (var transaction = context.Database.BeginTransaction())
//        {

//            var nacionalidad = new Nacionalidad() { };

//            context.Set<Nacionalidad>().Add(nacionalidad);

//            context.SaveChangesAsync();


//            var direcciones = new List<Direccion>() { };

//            context.Set<Direccion>().AddRange(direcciones);

//            context.SaveChangesAsync();

//            var person = new Persona()
//            {
//                IdNacionalidad = nacionalidad.IdNacionalidad
//            };

//            context.Set<Persona>().Add(person);

//            context.SaveChangesAsync();



//            foreach (var item in direcciones)
//            {

//                var personaDireccion = new PersonaDireccion()
//                {
//                    IdPersona = person.IdPersona,
//                    IdDireccion = item.IdDireccion
//                };

//                context.Set<PersonaDireccion>().Add(personaDireccion);

//                context.SaveChangesAsync();
//            }


//            var personasdireccion = direcciones.Select(item => new PersonaDireccion()
//            {

//                IdPersona = person.IdPersona,
//                IdDireccion = item.IdDireccion
//            }).ToList();


//            context.Set<PersonaDireccion>().AddRange(personasdireccion);

//            context.SaveChangesAsync();


//            transaction.Commit();
//        }
//    }
//    catch (Exception e_ex)
//    {

//        throw new InvalidOperationException("Transaction failed", e_ex);
//    }

//}
