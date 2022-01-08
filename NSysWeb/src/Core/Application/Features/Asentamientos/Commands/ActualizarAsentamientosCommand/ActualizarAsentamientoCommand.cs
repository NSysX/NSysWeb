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

namespace Application.Features.Asentamientos.Commands.ActualizarAsentamientosCommand
{
    public class ActualizarAsentamientoCommand : IRequest<Respuesta<int>>
    {
        public int IdAsentamiento { get; set; }
        public int IdAsentamientoTipo { get; set; }
        public int IdMunicipio { get; set; }
        public string Estatus { get; set; }
        public string Nombre { get; set; }
        public int CodigoPostal { get; set; }
    }

    public class ActualizarAsentamiento_Manejador : IRequestHandler<ActualizarAsentamientoCommand, Respuesta<int>>
    {
        private readonly IRepositorioAsync<Asentamiento> _repositorioAsync;
        private readonly IRepositorioAsync<AsentamientoTipo> _repositorioAsentamientoTipo;
        private readonly IRepositorioAsync<Municipio> _repositorioMunicipio;

        public ActualizarAsentamiento_Manejador(IRepositorioAsync<Asentamiento> repositorioAsync,
                                                IRepositorioAsync<AsentamientoTipo> repositorioAsentamientoTipo,
                                                IRepositorioAsync<Municipio> repositorioMunicipio)
        {
            this._repositorioAsync = repositorioAsync;
            this._repositorioAsentamientoTipo = repositorioAsentamientoTipo;
            this._repositorioMunicipio = repositorioMunicipio;
        }

        public async Task<Respuesta<int>> Handle(ActualizarAsentamientoCommand request, CancellationToken cancellationToken)
        {
            var asentamientoTipoExiste = await _repositorioAsentamientoTipo.GetByIdAsync(request.IdAsentamientoTipo, cancellationToken);

            if (asentamientoTipoExiste == null)
                throw new KeyNotFoundException($"No existe el Asentamiento Tipo con el Id = { request.IdAsentamientoTipo }");

            // verificamos que exista el municipio
            var municipioExiste = await _repositorioMunicipio.GetByIdAsync(request.IdMunicipio, cancellationToken);

            if (municipioExiste == null)
                throw new KeyNotFoundException($"No existe el Municipio con el Id = { request.IdMunicipio }");

            Asentamiento asentamiento = await _repositorioAsync.GetByIdAsync(request.IdAsentamiento, cancellationToken);

            if (asentamiento == null)
                throw new KeyNotFoundException($"No se encontro el Registro con el Id = { request.IdAsentamiento }");

            // actualizamos datos
            asentamiento.IdAsentamientoTipo = request.IdAsentamientoTipo;
            asentamiento.IdMunicipio = request.IdMunicipio;
            asentamiento.Estatus = request.Estatus;
            asentamiento.Nombre = request.Nombre;
            asentamiento.CodigoPostal = request.CodigoPostal;

            await _repositorioAsync.UpdateAsync(asentamiento, cancellationToken);

            return new Respuesta<int>(asentamiento.IdAsentamiento);
        }
    }
}
