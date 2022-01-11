using Application.DTOs;
using Application.Interfaces;
using Application.Specifications.Asentamientos;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Asentamientos.Queries.AsentamientosXParametros
{
    public class AsentamientosXParametrosQuery : IRequest<RespuestaPaginada<List<AsentamientoDTO>>>
    {
        public int NumeroDePagina { get; set; }
        public int RegistrosXPaginas { get; set; }
        public string Nombre { get; set; }
        public int CodigoPostal { get; set; }
    }

    public class AsentamientoXParametros_Manejador : IRequestHandler<AsentamientosXParametrosQuery, RespuestaPaginada<List<AsentamientoDTO>>>
    {
        private readonly IRepositorioAsync<Asentamiento> _repositorioAsync;
        private readonly IMapper _mapper;

        public AsentamientoXParametros_Manejador(IRepositorioAsync<Asentamiento> repositorioAsync, IMapper mapper)
        {
            this._repositorioAsync = repositorioAsync;
            this._mapper = mapper;
        }

        public async Task<RespuestaPaginada<List<AsentamientoDTO>>> Handle(AsentamientosXParametrosQuery request, CancellationToken cancellationToken)
        {
            var parametros = new AsentamientosXParametrosSpec(request.NumeroDePagina, request.RegistrosXPaginas, request.Nombre, request.CodigoPostal);

            List<Asentamiento> asentamientos = await _repositorioAsync.ListAsync(parametros, cancellationToken);

            List<AsentamientoDTO> asentamientoDTOs = _mapper.Map<List<AsentamientoDTO>>(asentamientos);

            return new RespuestaPaginada<List<AsentamientoDTO>>(asentamientoDTOs, request.NumeroDePagina, request.RegistrosXPaginas);
        }
    }
}
