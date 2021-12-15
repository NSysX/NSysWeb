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

namespace Application.Features.Estados.Commands
{
    public class InsertarEstadoCommand : IRequest<Respuesta<int>>
    {
        public string Estatus { get; set; }
        public string Nombre { get; set; }
        public string Abreviatura { get; set; }
    }

    public class InsertarEstado_Manejador : IRequestHandler<InsertarEstadoCommand, Respuesta<int>>
    {
        private readonly IRepositorioAsync<Estado> _repositorioAsync;
        private readonly IMapper _mapper;

        public InsertarEstado_Manejador(IRepositorioAsync<Estado> repositorio, IMapper mapper)
        {
            this._repositorioAsync = repositorio;
            this._mapper = mapper;
        }

        public async Task<Respuesta<int>> Handle(InsertarEstadoCommand request, CancellationToken cancellationToken)
        {
            Estado estado = _mapper.Map<Estado>(request);
            var resultado = await _repositorioAsync.AddAsync(estado, cancellationToken);
            return new Respuesta<int>(resultado.IdEstado);
        }
    }
}
