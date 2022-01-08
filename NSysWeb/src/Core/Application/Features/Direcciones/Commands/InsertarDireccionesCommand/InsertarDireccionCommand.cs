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
        private readonly IRepositorioAsync<Direccion> _repositorioAsync;
        private readonly IRepositorioAsync<Asentamiento> _repositorioAsentamiento;
        private readonly IMapper _mapper;

        public InsertarDireccion_Manejador(IRepositorioAsync<Direccion> repositorioAsync, 
                                           IRepositorioAsync<Asentamiento> repositorioAsentamiento,
                                           IMapper mapper)
        {
            this._repositorioAsync = repositorioAsync;
            this._repositorioAsentamiento = repositorioAsentamiento;
            this._mapper = mapper;
        }

        public async Task<Respuesta<int>> Handle(InsertarDireccionCommand request, CancellationToken cancellationToken)
        {
            // Verifico que exista el asentamiento
            var asentamientoExiste = await _repositorioAsentamiento.GetByIdAsync(request.IdAsentamiento, cancellationToken);
            if (asentamientoExiste == null)
                throw new KeyNotFoundException($"No se encontro el Asentamiento con el Id = { request.IdAsentamiento }");

            Direccion direccion = _mapper.Map<Direccion>(request);
            var resultado = await _repositorioAsync.AddAsync(direccion, cancellationToken);

            return new Respuesta<int>(resultado.IdDireccion);
        }
    }
}
