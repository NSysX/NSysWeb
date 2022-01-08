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

namespace Application.Features.Asentamientos.Commands.InsertarAsentamientosCommand
{
    public class InsertarAsentamientoCommand : IRequest<Respuesta<int>>
    {
        public int IdAsentamientoTipo { get; set; }
        public int IdMunicipio { get; set; }
        public string Estatus { get; set; }
        public string Nombre { get; set; }
        public int CodigoPostal { get; set; }
    }

    public class InsertarAsentamiento_Manejador : IRequestHandler<InsertarAsentamientoCommand, Respuesta<int>>
    {
        private readonly IRepositorioAsync<Asentamiento> _repositorioAsync;
        private readonly IRepositorioAsync<AsentamientoTipo> _repositorioAsentamientoTipo;
        private readonly IRepositorioAsync<Municipio> _repositorioMunicipio;
        private readonly IMapper _mapper;

        public InsertarAsentamiento_Manejador(IRepositorioAsync<Asentamiento> repositorioAsync,
                                              IRepositorioAsync<AsentamientoTipo> repositorioAsentamientoTipo, 
                                              IRepositorioAsync<Municipio> repositorioMunicipio, IMapper mapper)
        {
            this._repositorioAsync = repositorioAsync;
            this._repositorioAsentamientoTipo = repositorioAsentamientoTipo;
            this._repositorioMunicipio = repositorioMunicipio;
            this._mapper = mapper;
        }

        public async Task<Respuesta<int>> Handle(InsertarAsentamientoCommand request, CancellationToken cancellationToken)
        {
            // Verifico que exista el idAsentamientoTipo
            var existeAsentamientoTipo = await _repositorioAsentamientoTipo.GetByIdAsync(request.IdAsentamientoTipo, cancellationToken);

            if (existeAsentamientoTipo == null)
                throw new KeyNotFoundException($"No se encontro el Asentamiento Tipo con el Id = { request.IdAsentamientoTipo }");

            // Verifico que exista el Municipio
            var existeMunicipio = await _repositorioMunicipio.GetByIdAsync(request.IdMunicipio, cancellationToken);
            if (existeMunicipio == null)
                throw new KeyNotFoundException($"No se encontrod el Municipio con el Id = { request.IdMunicipio }");

            Asentamiento asentamiento = _mapper.Map<Asentamiento>(request);
            var respuesta = await _repositorioAsync.AddAsync(asentamiento, cancellationToken);

            return new Respuesta<int>(respuesta.IdAsentamiento);
        }
    }
}
