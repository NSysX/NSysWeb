using Application.DTOs;
using Application.Interfaces;
using Application.Specifications.Direcciones;
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

namespace Application.Features.Direcciones.Queries.DireccionesXParametros
{
    public class DireccionesXParametrosQuery : IRequest<RespuestaPaginada<List<DireccionDTO>>>
    {
        public int NumeroDePagina { get; set; }
        public int RegistrosXPagina { get; set; }
        public string Calle { get; set; }
    }

    public class DireccionesXParametros_Manejador : IRequestHandler<DireccionesXParametrosQuery, RespuestaPaginada<List<DireccionDTO>>>
    {
        private readonly IRepositorioAsync<Direccion> _repositorioAsyncDir;
        private readonly IMapper _mapper;

        public DireccionesXParametros_Manejador(IRepositorioAsync<Direccion> repositorioAsyncDir, IMapper mapper)
        {
            this._repositorioAsyncDir = repositorioAsyncDir;
            this._mapper = mapper;
        }

        public async Task<RespuestaPaginada<List<DireccionDTO>>> Handle(DireccionesXParametrosQuery request, CancellationToken cancellationToken)
        {
            List<Direccion> direcciones = await _repositorioAsyncDir.ListAsync(new DireccionesXParametrosSpec(request.NumeroDePagina, request.RegistrosXPagina, request.Calle), cancellationToken);

            List<DireccionDTO> direccionesDTOs = _mapper.Map<List<DireccionDTO>>(direcciones);

            return new RespuestaPaginada<List<DireccionDTO>>(direccionesDTOs, request.NumeroDePagina, request.RegistrosXPagina);
        }
    }
}
