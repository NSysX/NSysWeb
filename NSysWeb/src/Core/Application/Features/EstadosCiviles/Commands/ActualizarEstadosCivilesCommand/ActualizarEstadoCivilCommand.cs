﻿using Application.Interfaces;
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

namespace Application.Features.EstadosCiviles.Commands.ActualizarEstadosCivilesCommand
{
    public class ActualizarEstadoCivilCommand : IRequest<Respuesta<int>>
    {
        public int IdEstadoCivil { get; set; }
        public string Estatus { get; set; }
        public string Descripcion { get; set; }
    }

    public class ActualizarEstadoCivilCommand_Manejador : IRequestHandler<ActualizarEstadoCivilCommand, Respuesta<int>>
    {
        private readonly IRepositorioAsync<EstadoCivil> _repositorioAsync;
        private readonly IMapper _mapper;

        public ActualizarEstadoCivilCommand_Manejador(IRepositorioAsync<EstadoCivil> repositorioAsync, IMapper mapper)
        {
            this._repositorioAsync = repositorioAsync;
            this._mapper = mapper;
        }

        public async Task<Respuesta<int>> Handle(ActualizarEstadoCivilCommand request, CancellationToken cancellationToken)
        {
            EstadoCivil existe_estadoCivil = await _repositorioAsync.GetByIdAsync(request.IdEstadoCivil);

            if (existe_estadoCivil == null)
                throw new KeyNotFoundException($"No existe el Registro con el Id = {request.IdEstadoCivil}");

            existe_estadoCivil.Estatus = request.Estatus;
            existe_estadoCivil.Descripcion = request.Descripcion;

            await _repositorioAsync.UpdateAsync(existe_estadoCivil);

            return new Respuesta<int>(existe_estadoCivil.IdEstadoCivil);
        }
    }
}