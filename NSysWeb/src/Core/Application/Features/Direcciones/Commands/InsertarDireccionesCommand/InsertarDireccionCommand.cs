using Application.Interfaces;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Direcciones.Commands.InsertarDireccionesCommand
{
    public class InsertarDireccionCommand : IRequest<Respuesta<int>>
    {
        public int IdPersona { get; set; }
        public int IdAsentamiento { get; set; }
        public string Estatus { get; set; }
        public string Calle { get; set; }
        public string EntreLaCalle { get; set; }
        public string YlaCalle { get; set; }
        public string NumeroExterior { get; set; }
        public string NumeroInterior { get; set; }
        public double Latitud { get; set; }
        public double Longitud { get; set; }
        public string Referencia { get; set; }
        public string Foto { get; set; }
        public bool EsFiscal { get; set; }
    }

    public class InsertarDireccion_Manejador : IRequestHandler<InsertarDireccionCommand, Respuesta<int>>
    {
        private readonly IRepositorioAsync<PersonaDireccion> _repositorioAsyncPersonaDireccion;
        private readonly IRepositorioAsync<Persona> _repositorioAsyncPersona;
        private readonly IRepositorioAsync<Asentamiento> _repositorioAsentamiento;
        private readonly IMapper _mapper;

        public InsertarDireccion_Manejador(IRepositorioAsync<PersonaDireccion> repositorioAsyncPersonaDireccion,
                                           IRepositorioAsync<Persona> repositorioAsyncPersona,
                                           IRepositorioAsync<Asentamiento> repositorioAsentamiento,
                                           IMapper mapper)
        {
            this._repositorioAsyncPersonaDireccion = repositorioAsyncPersonaDireccion;
            this._repositorioAsyncPersona = repositorioAsyncPersona;
            this._repositorioAsentamiento = repositorioAsentamiento;
            this._mapper = mapper;
        }

        public async Task<Respuesta<int>> Handle(InsertarDireccionCommand request, CancellationToken cancellationToken)
        {
            // Verificao que exista la Persona
            var personaExiste = await _repositorioAsyncPersona.GetByIdAsync(request.IdPersona, cancellationToken);
            if (personaExiste == null)
                throw new KeyNotFoundException($"No Existe Persona con el Id = { request.IdPersona }");

            // Verifico que exista el asentamiento
            var asentamientoExiste = await _repositorioAsentamiento.GetByIdAsync(request.IdAsentamiento, cancellationToken);
            if (asentamientoExiste == null)
                throw new KeyNotFoundException($"No Existe Asentamiento con el Id = { request.IdAsentamiento }");

            //
            //creo el objeto PersonaDireccion
            PersonaDireccion personaDireccion = new()
            {
                IdPersona = request.IdPersona,
                Direccion = _mapper.Map<Direccion>(request)
            };

            PersonaDireccion personaDirec = await _repositorioAsyncPersonaDireccion.AddAsync(personaDireccion, cancellationToken);

            return new Respuesta<int>(personaDirec.IdDireccion);
        }
    }
}
