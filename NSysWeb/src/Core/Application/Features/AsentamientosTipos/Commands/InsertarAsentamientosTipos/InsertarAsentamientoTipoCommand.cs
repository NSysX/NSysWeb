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

namespace Application.Features.AsentamientosTipos.Commands.InsertarAsentamientosTipos
{
    public class InsertarAsentamientoTipoCommand : IRequest<Respuesta<int>>
    {
        public string Estatus { get; set; }
        public string Nombre { get; set; }
        public string Abreviatura { get; set; }
    }

    public class InsertarAsentamientoTipo_Manejador : IRequestHandler<InsertarAsentamientoTipoCommand, Respuesta<int>>
    {
        private readonly IRepositorioAsync<AsentamientoTipo> _repositorioAsync;
        private readonly IMapper _mapper;

        public InsertarAsentamientoTipo_Manejador(IRepositorioAsync<AsentamientoTipo> repositorioAsync, IMapper mapper)
        {
            this._repositorioAsync = repositorioAsync;
            this._mapper = mapper;
        }

        public async Task<Respuesta<int>> Handle(InsertarAsentamientoTipoCommand request, CancellationToken cancellationToken)
        {
            AsentamientoTipo asentamientoTipo = _mapper.Map<AsentamientoTipo>(request);
            var resultado = await _repositorioAsync.AddAsync(asentamientoTipo, cancellationToken);
            return new Respuesta<int>(resultado.IdAsentamientoTipo);
        }
    }
}
