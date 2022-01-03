using Application.Exceptions;
using Application.Interfaces;
using Application.Specifications.EstadosCiviles;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System.Collections.Generic;
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
            var datosAVerificar = new ExisteEstadoCivilSpec(request.Descripcion, request.IdEstadoCivil);
            var existe = await _repositorioAsync.GetBySpecAsync(datosAVerificar, cancellationToken);

            // Si trae algun registro que coincida
            if (existe != null)
                throw new ExcepcionesDeAPI("No se puede Actualizar con datos Duplicados");

            EstadoCivil existe_estadoCivil = await _repositorioAsync.GetByIdAsync(request.IdEstadoCivil, cancellationToken);

            if (existe_estadoCivil == null)
                throw new KeyNotFoundException($"No existe el Registro con el Id = {request.IdEstadoCivil}");

            existe_estadoCivil.Estatus = request.Estatus;
            existe_estadoCivil.Descripcion = request.Descripcion;

            await _repositorioAsync.UpdateAsync(existe_estadoCivil, cancellationToken);

            return new Respuesta<int>(existe_estadoCivil.IdEstadoCivil);
        }
    }
}
