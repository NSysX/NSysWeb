using Application.DTOs;
using Application.Interfaces;
using Application.Specifications.AsentamientosTipos;
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

namespace Application.Features.AsentamientosTipos.Queries.ListarAsentamientosTipos
{
    public class ListarAsentamientosTiposQuery : IRequest<RespuestaPaginada<List<AsentamientoTipoDTO>>>
    {
        public int NumeroPagina { get; set; }
        public int RegistrosXPagina { get; set; }
        public string Estatus { get; set; }
        public string Nombre { get; set; }
        public string Abeviatura { get; set; }
    }

    public class ListarAsentamientoTipo_Manejador : IRequestHandler<ListarAsentamientosTiposQuery, RespuestaPaginada<List<AsentamientoTipoDTO>>>
    {
        private readonly IRepositorioAsync<AsentamientoTipo> _repositorioAsync;
        private readonly IMapper _mapper;

        public ListarAsentamientoTipo_Manejador(IRepositorioAsync<AsentamientoTipo> repositorioAsync, IMapper mapper)
        {
            this._repositorioAsync = repositorioAsync;
            this._mapper = mapper;
        }

        public async Task<RespuestaPaginada<List<AsentamientoTipoDTO>>> Handle(ListarAsentamientosTiposQuery request, CancellationToken cancellationToken)
        {
            List<AsentamientoTipo> asentamientoTipos = await _repositorioAsync.ListAsync(new ListarAsentamientosTiposSpec(request.RegistrosXPagina, request.NumeroPagina, request.Estatus, request.Nombre, request.Abeviatura), cancellationToken);

            List<AsentamientoTipoDTO> asentamientoTipoDTOs = _mapper.Map<List<AsentamientoTipoDTO>>(asentamientoTipos);

            return new RespuestaPaginada<List<AsentamientoTipoDTO>>(asentamientoTipoDTOs, request.NumeroPagina, request.RegistrosXPagina);
        }
    }
}
