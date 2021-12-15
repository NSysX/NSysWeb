using Application.Interfaces;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Estados.Commands.ActualizarEstadosCommand
{
    public class ActualizarEstadoCommand : IRequest<Respuesta<int>>
    {
        public int IdEstado { get; set; }
        public string Estatus { get; set; }
        public string Nombre { get; set; }
        public string Abreviatura { get; set; }
    }

    public class ActualizarEstado_Manejador : IRequestHandler<ActualizarEstadoCommand, Respuesta<int>>
    {
        private readonly IRepositorioAsync<Estado> _repositorioAsync;
        private readonly IMapper _mapper;

        public ActualizarEstado_Manejador(IRepositorioAsync<Estado> repositorioAsync, IMapper mapper)
        {
            this._repositorioAsync = repositorioAsync;
            this._mapper = mapper;
        }

        public async Task<Respuesta<int>> Handle(ActualizarEstadoCommand request, CancellationToken cancellationToken)
        {
            // se verifica que exista 
            Estado estado = await _repositorioAsync.GetByIdAsync(request.IdEstado, cancellationToken);

            if (estado == null)
                throw new KeyNotFoundException($"No se encuestra el registro con el Id = { request.IdEstado }");

            estado.Estatus = request.Estatus.Trim();
            estado.Nombre = request.Nombre.Trim();
            estado.Abreviatura = request.Abreviatura.Trim();

            await _repositorioAsync.UpdateAsync(estado);

            return new Respuesta<int>(estado.IdEstado);
        }
    }
}
