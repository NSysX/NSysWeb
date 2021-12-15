using Application.DTOs;
using Application.Interfaces;
using Application.Specifications.Estados;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Estados.Queries.ListarEstados
{
    public class ListarEstadosQuery : IRequest<RespuestaPaginada<List<EstadoDTO>>>
    {
        public int NumeroDePagina { get; set; }
        public int RegistrosXPagina { get; set; }
        public string Estatus { get; set; }
        public string Nombre { get; set; }
        public string Abreviatura { get; set; }
    }

    public class ListarEstados_Manejador : IRequestHandler<ListarEstadosQuery, RespuestaPaginada<List<EstadoDTO>>>
    {
        private readonly IRepositorioAsync<Estado> _repositorioAsync;
        private readonly IMapper _mapper;

        public ListarEstados_Manejador(IRepositorioAsync<Estado> repositorioAsync, IMapper mapper)
        {
            this._repositorioAsync = repositorioAsync;
            this._mapper = mapper;
        }

        public async Task<RespuestaPaginada<List<EstadoDTO>>> Handle(ListarEstadosQuery request, CancellationToken cancellationToken)
        {
            List<Estado> estado = await _repositorioAsync.ListAsync(new EstadosPaginadosSpec( request.RegistrosXPagina, request.NumeroDePagina,  request.Estatus, request.Nombre, request.Abreviatura ));

            List<EstadoDTO> estadoDTOs = _mapper.Map<List<EstadoDTO>>(estado);

            return new RespuestaPaginada<List<EstadoDTO>>(estadoDTOs, request.NumeroDePagina, request.RegistrosXPagina);
        }
    }
}
