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

namespace Application.Features.Estados.Commands.EliminarEstadosCommand
{
    public class EliminarEstadoCommand : IRequest<Respuesta<int>>
    {
        public int IdEstado { get; set; }
    }

    public class EliminarEstado_Manejador : IRequestHandler<EliminarEstadoCommand, Respuesta<int>>
    {
        private readonly IRepositorioAsync<Estado> _repositoryAsync;
        private readonly IMapper _mapper;

        public EliminarEstado_Manejador(IRepositorioAsync<Estado> repositoryAsync, IMapper mapper)
        {
            this._repositoryAsync = repositoryAsync;
            this._mapper = mapper;
        }

        public async Task<Respuesta<int>> Handle(EliminarEstadoCommand request, CancellationToken cancellationToken)
        {
            Estado estado = await _repositoryAsync.GetByIdAsync(request.IdEstado);

            if (estado == null) 
                throw new KeyNotFoundException($"No se encontro el registro con el Id = {request.IdEstado}");

            await _repositoryAsync.DeleteAsync(estado);

            return new Respuesta<int>(estado.IdEstado);
        }
    }
}
