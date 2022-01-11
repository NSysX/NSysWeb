using Application.Interfaces;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities;
using MediatR;
using NetTopologySuite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Direcciones.Commands.ActualizarDireccionesCommand
{
    public class ActualizarDireccionCommand : IRequest<Respuesta<int>>
    {
        public int IdDireccion { get; set; }
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

    public class ActualizarDireccion_Manejador : IRequestHandler<ActualizarDireccionCommand, Respuesta<int>>
    {
        private readonly IRepositorioAsync<Asentamiento> _repositorioAsyncAsen;
        private readonly IRepositorioAsync<Direccion> _repositorioAsyncDir;
        private readonly IMapper _mapper;

        public ActualizarDireccion_Manejador(IRepositorioAsync<Asentamiento> repositorioAsyncAsen,
                                             IRepositorioAsync<Direccion> repositorioAsyncDir,
                                             IMapper mapper)
        {
            this._repositorioAsyncAsen = repositorioAsyncAsen;
            this._repositorioAsyncDir = repositorioAsyncDir;
            this._mapper = mapper;
        }

        public async Task<Respuesta<int>> Handle(ActualizarDireccionCommand request, CancellationToken cancellationToken)
        {
            // Verifico que Exista el Asentamiento
            Asentamiento asentamiento = await _repositorioAsyncAsen.GetByIdAsync(request.IdAsentamiento, cancellationToken);
            if (asentamiento == null)
                throw new KeyNotFoundException($"No Existe Asentemiento con Id = { request.IdAsentamiento }");

            var direccionExiste = await _repositorioAsyncDir.GetByIdAsync(request.IdDireccion, cancellationToken);
            if (direccionExiste == null)
                throw new KeyNotFoundException($"No Existe Direccion con Id = { request.IdDireccion }");

            Direccion direccion = _mapper.Map<Direccion>(request);

            direccion.FechaCreacion = direccionExiste.FechaCreacion;
            direccion.UsuarioCreacion = direccionExiste.UsuarioCreacion;

            await _repositorioAsyncDir.UpdateAsync(direccion, cancellationToken);

            return new Respuesta<int>(direccion.IdDireccion);
        }
    }
}
