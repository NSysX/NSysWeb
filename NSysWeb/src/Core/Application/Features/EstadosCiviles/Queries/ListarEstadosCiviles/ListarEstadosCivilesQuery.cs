using Application.DTOs;
using Application.Interfaces;
using Application.Specifications;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.EstadosCiviles.Queries.ListarEstadosCivilesQuery
{
    public class ListarEstadosCivilesQuery : IRequest<RespuestaPaginada<List<EstadoCivilDTO>>>
    {
        public int NumeroDePagina { get; set; }
        public int RegistroXPagina { get; set; }
        public string Descripcion { get; set; }
        public string Estatus { get; set; }
    }

        public class ListarEstadosCiviles_Manejador : IRequestHandler<ListarEstadosCivilesQuery, RespuestaPaginada<List<EstadoCivilDTO>>>
        {
            private readonly IRepositorioAsync<EstadoCivil> _repositorioEstadoCivil;
            private readonly IMapper _mapper;

            public ListarEstadosCiviles_Manejador(IRepositorioAsync<EstadoCivil> repositorioEstadoCivil, IMapper mapper)
            {
                this._repositorioEstadoCivil = repositorioEstadoCivil;
                this._mapper = mapper;
            }

            public async Task<RespuestaPaginada<List<EstadoCivilDTO>>> Handle(ListarEstadosCivilesQuery request, CancellationToken cancellationToken)
            {
                var estadosCiviles = await _repositorioEstadoCivil.ListAsync(new EstadosCivilesPaginadosSpec(request.RegistroXPagina, request.NumeroDePagina, request.Descripcion, request.Estatus));

                var estadosCivilesDTO = _mapper.Map<List<EstadoCivilDTO>>(estadosCiviles);

                return new RespuestaPaginada<List<EstadoCivilDTO>>(estadosCivilesDTO, request.NumeroDePagina, request.RegistroXPagina);
            }
        }
    
}
