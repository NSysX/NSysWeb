using Application.DTOs;
using Application.Interfaces;
using Application.Specifications.Nacionalidades;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Nacionalidades.Queries
{
    public class ListarNacionalidadesQuery : IRequest<RespuestaPaginada<List<NacionalidadDTO>>>
    {
        public int NumeroDePagina { get; set; }
        public int RegistrosXPagina { get; set; }
        public string Descripcion { get; set; }
        public string Estatus { get; set; }
    }

    public class ListarNacionalidad_Manejador : IRequestHandler<ListarNacionalidadesQuery, RespuestaPaginada<List<NacionalidadDTO>>>
    {
        private readonly IRepositorioAsync<Nacionalidad> _respositorioAsync;
        private readonly IMapper _mapper;

        public ListarNacionalidad_Manejador(IRepositorioAsync<Nacionalidad> respositorioAsync, IMapper mapper)
        {
            this._respositorioAsync = respositorioAsync;
            this._mapper = mapper;
        }

        public async Task<RespuestaPaginada<List<NacionalidadDTO>>> Handle(ListarNacionalidadesQuery request, CancellationToken cancellationToken)
        {
            List<Nacionalidad> nacionalidades = await _respositorioAsync.ListAsync(new NacionalidadesPaginadasSpec(request.RegistrosXPagina, request.NumeroDePagina, request.Descripcion, request.Estatus));

            List<NacionalidadDTO> nacionalidadesDTOs = _mapper.Map<List<NacionalidadDTO>>(nacionalidades);

            return new RespuestaPaginada<List<NacionalidadDTO>>(nacionalidadesDTOs, request.NumeroDePagina, request.RegistrosXPagina);
        }
    }
}
